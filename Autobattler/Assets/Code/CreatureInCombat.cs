using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auttobattler.Combat
{
    public class CreatureInCombat
    {
        public Grid side;
        public Position Position { get => side.GetPosition(this); }

        public Stats baseStats;
        public InCombatStats stats;

        public AttackModule attackModule;

        public CreatureInCombat()
        {
            attackModule = new AttackModule(this);
            baseStats = new Stats();
        }

        public void Refresh()
        {
            attackModule.Refresh();
        }
    }

    public class InCombatStats
    {
        public ValuePair health;
        public float attack;
        public float habilityPower;

        //
        public float timeToAttack = Constants.VALUE_TO_COMPLETE_AN_ATTACK;
        public float attackSpeed;

        //Ultimate
        public float manaRegen;
        public float manaToCast;

        //Habilities
        public float cooldownReduction;

        //How much get tired in each action
        public float encumbrance;
        public float Reinvigoration;
        public float maxFatigue = 100;
    }


    public class AttackModule
    {
        public ValuePair progress;
        private CreatureInCombat parent;
        public ObjectiveTypes objetive;

        public InCombatStats Stats { get => parent.stats; }

        public AttackModule(CreatureInCombat parent, ObjectiveTypes objetive)
        {
            this.parent = parent;
            this.objetive = objetive;

            progress = new ValuePair(ref Stats.timeToAttack, 0);
        }

        public AttackModule(CreatureInCombat parent)
        {
            this.parent = parent;
        }

        public void Refresh()
        {
            progress.Current += Time.fixedDeltaTime * parent.stats.attackSpeed;
            while (progress.Current >= Stats.timeToAttack)
            {
                progress.Current -= Stats.timeToAttack;

                Attack();
            }
        }

        private void Attack()
        {
            ObjetivesProcessor.GetObjetives(objetive, parent.Position, parent.side.Battlefield);
        }
    }

    #region OBJETIVES_SELECTOR
    public enum ObjectiveTypes
    {
        ENEMY_CLOSEST
    }

    public static class ObjetivesProcessor
    {
        static List<CreatureInCombat> objetives = new List<CreatureInCombat>(6);

        public static List<CreatureInCombat> GetObjetives(ObjectiveTypes type, Position pos, Battlefield battleField)
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

        public static CreatureInCombat GetClosest(Position pos, CombatSlot[] column)
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

            CreatureInCombat creature = SearchUntilGetOne(order, column);
            if (creature == null)
                creature = SearchUntilGetOne(order, column);

            return creature;
        }

        public static CreatureInCombat SearchUntilGetOne(int[] order, CombatSlot[] column)
        {
            foreach (int i in order)
            {
                CreatureInCombat c = column[i].creature;
                if (c != null) return c;
            }

            return null;
        }
    }

    #endregion

    public class ValuePair
    {
        //Fields
        private float max;
        public float Max
        {
            get => max;
            set
            {
                max = value;
                OnMaxValueChanged(current);
            }
        }

        private float current;
        public float Current
        {
            get => current;
            set
            {
                current = value;
                OnCurrentValueChanged(current);
            }
        }
       
        //Delegates
        public delegate void CurrentValueChanged(float value);
        public event CurrentValueChanged OnCurrentValueChanged;

        public delegate void MaxValueChanged(float value);
        public event MaxValueChanged OnMaxValueChanged;

        public ValuePair(ref float max, float current)
        {
            this.max = max;
            this.current = current;
        }
    }
}