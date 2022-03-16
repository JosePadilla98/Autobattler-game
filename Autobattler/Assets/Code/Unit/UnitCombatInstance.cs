﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Auttobattler.Ultimates;

namespace Auttobattler.Combat
{
    public class UnitCombatInstance
    {
        public Grid grid;
        public CombatValuesWrapper values;
        public Ultimate ultimate;
        public Unit gameObject;

        #region PROPERTIES
        public Position Position { get => grid.GetPosition(this); }
        #endregion

        #region SYSTEMS

        public AttackSystem attackSys;
        public DefenseSystem defenseSys;
        public HealthSystem healthSys;
        public UltimateSystem ultimateSys;

        #endregion

        public UnitCombatInstance(BuildedUnit build, Side side)
        {
            values = new CombatValuesWrapper(build);
            attackSys = new AttackSystem(this);
            defenseSys = new DefenseSystem(this);
            healthSys = new HealthSystem(this);
            ultimateSys = new UltimateSystem(this);
            ultimate = build.ultScriptable.GetUltimate();

            if (side == Side.RIGHT)
                this.grid = Battlefield.Instance.rightGrid;
            else
                this.grid = Battlefield.Instance.leftGrid;
        }

        public void Refresh()
        {
            attackSys.Refresh();
            ultimateSys.Refresh();
        }

        public void LaunchAttack(AttackType attackType, float power)
        {
            float attackValue = (attackType == AttackType.PHYSICAL) ? values.attack.Value : values.magic.Value;

            List<UnitCombatInstance> objetives = ObjetivesProcessor.GetObjetives(ObjectiveTypes.ENEMY_CLOSEST, Position, Battlefield.Instance);
            foreach (var unit in objetives)
            {
                float rawValue = attackValue * power * Constants.K_DAMAGE_CONSTANT;
                unit.defenseSys.BeAttacked(new RawDamageData(rawValue, AttackType.PHYSICAL));
            }
        }
    }

    public class CombatValuesWrapper
    {
        public int level;

        public CombatValue maxHealth;
        public CombatValue health;

        public CombatValue attack;
        public CombatValue attackSpeed;
        public CombatValue attackProgress;
        public CombatValue attackDuration;
        public CombatValue attackPower;

        public CombatValue magic;

        public CombatValue ultimateRegen;
        public CombatValue ultimateProgress;
        public CombatValue ultimateChargeToCast = new CombatValue(100f);

        public CombatValue defense;

        public CombatValuesWrapper(BuildedUnit build)
        {
            BuildStatsWrapper stats = build.statsWrapper;
            this.level = stats.level;

            maxHealth = new CombatValue(stats.health.Get);
            health = new CombatValue(stats.health.Get);

            attack = new CombatValue(stats.attack.Get, stats.level);
            magic = new CombatValue(stats.magic.Get, stats.level);
            defense = new CombatValue(stats.defense.Get, stats.level);

            attackSpeed = new CombatValue(stats.attackSpeed.Get);
            attackProgress = new CombatValue(0);
            attackDuration = new CombatValue(stats.attackDuration.Get);
            attackPower = new CombatValue(stats.attackPower.Get);

            ultimateRegen = new CombatValue(stats.ultimateRegen.Get);
            ultimateProgress = new CombatValue(0);
        }
    }

    public class CombatValue
    {
        private float value;
        public delegate void ValueChanged(float value);
        public event ValueChanged OnValueChanged;
        public float Value
        {
            get => value;
            set
            {
                this.value = value;
                OnValueChanged?.Invoke(this.value);
            }
        }

        public CombatValue(float value)
        {
            this.value = value;
        }

        public CombatValue(float value, int level)
        {
            this.value = value + ((level - 1) * value * Constants.LEVEL_STATS_INCREMENT_FACTOR);
        }
    }

    #region ATTACK DATA TYPES

    public enum AttackType
    {
        PHYSICAL, MAGICAL
    }

    public struct RawDamageData
    {
        public float rawDamage;
        public AttackType type;

        public RawDamageData(float rawDamage, AttackType type)
        {
            this.rawDamage = rawDamage;
            this.type = type;
        }
    }

    #endregion

    #region SYSTEMS

    public abstract class CombatSystem
    {
        protected UnitCombatInstance parent;

        public CombatSystem(UnitCombatInstance parent)
        {
            this.parent = parent;
        }
    }

    public class AttackSystem : CombatSystem
    {
        public AttackSystem(UnitCombatInstance parent) : base(parent) { }

        #region Properties
        public int Level { get => parent.values.level; }
        public float Attack { get => parent.values.attack.Value; set => parent.values.attack.Value = value; }
        public float Progress { get => parent.values.attackProgress.Value; set => parent.values.attackProgress.Value = value; }
        public float AttackSpeed { get => parent.values.attackSpeed.Value; set => parent.values.attackSpeed.Value = value; } 
        public float Duration { get => parent.values.attackDuration.Value; set => parent.values.attackDuration.Value = value; }
        public float Power { get => parent.values.attackPower.Value; }
        #endregion 

        public void Refresh()
        {
            Progress += Time.fixedDeltaTime * AttackSpeed;
            while (Progress >= Duration)
            {
                Progress -= Duration;

                LaunchBasicAttack();
            }
        }

        public delegate void AttackEvent();
        public event AttackEvent OnAttack;

        private void LaunchBasicAttack()
        {
            parent.LaunchAttack(AttackType.PHYSICAL, Power);
            OnAttack?.Invoke();
        }
    }

    public class UltimateSystem : CombatSystem
    {
        public UltimateSystem(UnitCombatInstance parent) : base(parent) { }

        #region Properties
        public int Level { get => parent.values.level; }
        public float Attack { get => parent.values.attack.Value; set => parent.values.attack.Value = value; }
        public float Magic { get => parent.values.magic.Value; set => parent.values.magic.Value = value; }
        public Ultimate Ultimate { get => parent.ultimate; }
        public float ChargeRate { get => parent.values.ultimateRegen.Value; set => parent.values.ultimateRegen.Value = value; }
        public float Progress { get => parent.values.ultimateProgress.Value; set => parent.values.ultimateProgress.Value = value; }
        public float ChargeToCast { get => parent.values.ultimateChargeToCast.Value; set => parent.values.ultimateChargeToCast.Value = value; }
        #endregion

        public delegate void UltimateEvent();
        public event UltimateEvent OnUltimateCasted;

        public void Refresh()
        {
            Progress += Time.fixedDeltaTime * ChargeRate;
            while (Progress >= ChargeToCast)
            {
                Progress -= ChargeToCast;
                LaunchUltimate();
            }
        }

        public void LaunchUltimate()
        {
            Ultimate?.Cast(parent);
        }
    }
  
    public class DefenseSystem : CombatSystem
    {
        public DefenseSystem(UnitCombatInstance parent) : base(parent) { }

        #region Properties
        public float Defense { get => parent.values.defense.Value; set => parent.values.attack.Value = value; }
        #endregion 

        public void BeAttacked(RawDamageData data)
        {
            float damage = data.rawDamage / Defense;
            parent.healthSys.ReceiveDamage(damage);
        }
    }

    public class HealthSystem : CombatSystem
    {
        public HealthSystem(UnitCombatInstance parent) : base(parent) { }

        #region Properties
        public float MaxHealth { get => parent.values.maxHealth.Value; set => parent.values.maxHealth.Value = value; }
        public float Health { get => parent.values.health.Value; set => parent.values.health.Value = value; }
        #endregion 

        public void ReceiveDamage(float damage)
        {
            Health -= damage;
            NumberPopup.Create(parent.gameObject.numberPopupsLocation, (int)damage, NumberPopupTypes.DAMAGE); 
        }
    }

    #endregion

    #region OBJETIVES PROCCESOR
    public enum ObjectiveTypes
    {
        ENEMY_CLOSEST
    }

    public static class ObjetivesProcessor
    {
        static List<UnitCombatInstance> objetives = new List<UnitCombatInstance>(6);

        public static List<UnitCombatInstance> GetObjetives(ObjectiveTypes type, Position ownPos, Battlefield battleField)
        {
            objetives.Clear();

            switch (type)
            {
                case ObjectiveTypes.ENEMY_CLOSEST:

                    Grid gridObjetive;
                    if (ownPos.side == Side.LEFT)
                        gridObjetive = battleField.rightGrid;
                    else 
                        gridObjetive = battleField.leftGrid;

                    UnitCombatInstance creature = GetClosest(ownPos, gridObjetive);
                    objetives.Add(creature);
                    break;
            }

            return objetives;
        }

        public static UnitCombatInstance GetClosest(Position pos, Grid grid)
        {
            int[] order = null;

            switch (pos.heigh)
            {
                case 1:
                    order = new int[] { 1, 2, 3 };
                    break;

                case 2:
                    order = new int[] { 2, 1, 3 };
                    break;

                case 3:
                    order = new int[] { 3, 2, 1 };
                    break;
            }

            UnitCombatInstance unit = SearchUntilGetOne(order, grid.front);
            if (unit == null)
                unit = SearchUntilGetOne(order, grid.back);

            return unit;
        }

        public static UnitCombatInstance SearchUntilGetOne(int[] order, CombatSlot[] column)
        {
            foreach (int i in order)
            {
                UnitCombatInstance c = column[i].unit;
                if (c != null) return c;
            }

            return null;
        }
    }

    #endregion
}