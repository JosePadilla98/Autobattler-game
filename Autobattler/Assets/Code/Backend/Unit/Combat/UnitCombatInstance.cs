using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Auttobattler.MutationsSystem;

namespace Auttobattler.Combat
{
    public class UnitCombatInstance
    {
        public Team Team { get => CombatController.Instance.GetFighterTeam(this); }
        public Position Position { get => Battlefield.Instance.GetFighterPosition(this); }
        public CombatValues combatValues;

        private readonly Unit unit;
        public Stats Stats { get { return unit.stats; } }
        public List<MutationModel> Mutations { get => unit.mutations;  }

        #region SYSTEMS

        public HealthSystem healthSys;
        public AttackSystem attackSys;
        public DefenseSystem defenseSys;
        public ManaSystem manaSys;
        public VigorSystem vigorSys;

        #endregion

        public UnitCombatInstance(Unit unit)
        {
           
        }

        public void Refresh()
        {
            attackSys.Refresh();
            manaSys.Refresh();
            vigorSys.Refresh();
        }

   
    }

    public class CombatValues
    {
        public CombatValues(Unit build)
        {
            
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
            LaunchAttack(AttackType.PHYSICAL, Power);
            OnAttack?.Invoke();
        }

        public void LaunchAttack(AttackType attackType, float power)
        {
            float attackValue = (attackType == AttackType.PHYSICAL) ? values.attack.Value : values.magic.Value;

            List<UnitCombatInstance> objetives = TargetsProcessor.GetObjetives(TargetTypes.ENEMY_CLOSEST, Position, Battlefield.Instance);
            foreach (var unit in objetives)
            {
                float rawValue = attackValue * power * Constants.K_DAMAGE_CONSTANT;
                unit.defenseSys.BeAttacked(new RawDamageData(rawValue, AttackType.PHYSICAL));
            }
        }
    }

    public class UltimateSystem : CombatSystem
    {
        public UltimateSystem(UnitCombatInstance parent) : base(parent) { }

        #region Properties

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
        public float MagicDefense { get => parent.values.magicDefense.Value; set => parent.values.magicDefense.Value = value; }
        #endregion 

        public void BeAttacked(RawDamageData data)
        {
            float defenseValue = (data.type == AttackType.PHYSICAL) ? Defense : MagicDefense;
            float damage = data.rawDamage / defenseValue;
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

            //La representacion debería de engancharse a un delegado que se lanza aquí
            //NumberPopup.Create(parent.gameObject.numberPopupsLocation, (int)damage, NumberPopupTypes.DAMAGE);
        }
    }

    public class ManaSystem : CombatSystem
    {
        public ManaSystem(UnitCombatInstance parent) : base(parent) { }

        #region Properties
        public float MaxMana { get => parent.values.maxMana.Value; set => parent.values.maxMana.Value = value; }
        public float CurrentMana { get => parent.values.currentMana.Value; set => parent.values.currentMana.Value = value; }
        public float ManaRegen { get => parent.values.manaRegen.Value; set => parent.values.manaRegen.Value = value; }
        #endregion 

        public void Refresh()
        {
            CurrentMana += Time.fixedDeltaTime * ManaRegen;
            if(CurrentMana > MaxMana)
            {
                CurrentMana = MaxMana;
            }
        }
    }

    public class VigorSystem : CombatSystem
    {
        public VigorSystem(UnitCombatInstance parent) : base(parent) { }

        #region Properties
        public float MaxVigor { get => parent.values.vigor.Value; set => parent.values.vigor.Value = value; }
        public float CurrentVigor { get => parent.values.currentVigor.Value; set => parent.values.currentVigor.Value = value; }
        public float Reinvigoration { get => parent.values.reinvigoration.Value; set => parent.values.reinvigoration.Value = value; }
        #endregion 

        public void Refresh()
        {
            CurrentVigor += Time.fixedDeltaTime * Reinvigoration;
            if (CurrentVigor > MaxVigor)
            {
                CurrentVigor = MaxVigor;
            }
        }
    }

    #endregion

}