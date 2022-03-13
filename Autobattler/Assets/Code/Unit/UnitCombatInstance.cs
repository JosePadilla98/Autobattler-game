using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auttobattler.Combat
{
    public class UnitCombatModule 
    {
        public Grid hisSide;
        public CombatValuesWrapper values;

        #region PROPERTIES

        public Position Position { get => hisSide.GetPosition(this); }

        #endregion

        #region SYSTEMS

        public AttackSystem attackSys;

        #endregion

        public UnitCombatModule(BuildedUnit build)
        {
            attackSys = new AttackSystem(this);
            values = new CombatValuesWrapper(build);
        }

        public void Refresh()
        {
            attackSys.Refresh();
        }
    }

    public class CombatValuesWrapper
    {
        public CombatValue attackSpeed;
        public CombatValue attackProgress;
        public CombatValue attackDuration;
        public CombatValue attackPower;

        public CombatValuesWrapper(BuildedUnit build)
        {
            attackSpeed = new CombatValue(build.attackSpeed.Get);
            attackProgress = new CombatValue(0);
            attackDuration = new CombatValue(build.attackDuration.Get);
            attackPower = new CombatValue(build.attackPower.Get);
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
                OnValueChanged(this.value);
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

    public class AttackSystem
    {
        private UnitCombatModule parent;

        public float Progress { get => parent.values.attackProgress.Value; set => parent.values.attackProgress.Value = value; }
        public float AttackSpeed { get => parent.values.attackSpeed.Value; set => parent.values.attackSpeed.Value = value; } 
        public float MaxAmount { get => parent.values.attackDuration.Value; set => parent.values.attackDuration.Value = value; }

        public AttackSystem(UnitCombatModule parent)
        {
            this.parent = parent;
        }

        public void Refresh()
        {
            Progress += Time.fixedDeltaTime * AttackSpeed;
            while (Progress >= MaxAmount)
            {
                Progress -= MaxAmount;

                Attack();
            }
        }

        private void Attack()
        {
            //ObjetivesProcessor.GetObjetives(ObjectiveTypes.ENEMY_CLOSEST, parent.Position, Battlefield.Instance);
        }
    }

    #region OBJETIVES_PROCCESOR
    public enum ObjectiveTypes
    {
        ENEMY_CLOSEST
    }

    public static class ObjetivesProcessor
    {
        static List<UnitCombatModule> objetives = new List<UnitCombatModule>(6);

        public static List<UnitCombatModule> GetObjetives(ObjectiveTypes type, Position pos, Battlefield battleField)
        {
            objetives.Clear();

            switch (type)
            {
                case ObjectiveTypes.ENEMY_CLOSEST:

                    //CreatureInCombat creature = GetClosest(pos, );

                    //objetives.Add(creature);
                    break;
            }

            return objetives;
        }

        public static UnitCombatModule GetClosest(Position pos, CombatSlot[] column)
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

            UnitCombatModule unit = SearchUntilGetOne(order, column);
            if (unit == null)
                unit = SearchUntilGetOne(order, column);

            return unit;
        }

        public static UnitCombatModule SearchUntilGetOne(int[] order, CombatSlot[] column)
        {
            foreach (int i in order)
            {
                UnitCombatModule c = column[i].unit;
                if (c != null) return c;
            }

            return null;
        }
    }

    #endregion
}