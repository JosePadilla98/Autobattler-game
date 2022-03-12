using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace auttobattler
{
    public class CreatureCombatLogic
    {
        public ValuePair health;
        public AttackProgressModule attackModule;
        public CreatureStats stats;

        public CreatureCombatLogic()
        {
            attackModule = new AttackProgressModule(this);
            stats = new CreatureStats();
        }

        public void Refresh()
        {
            attackModule.Refresh();
        }
    }

    public class CreatureStats
    {
        public float attackSpeed = 18f;
    }

    public class AttackProgressModule
    {
        public ValuePair progress = new ValuePair(Constants.VALUE_TO_COMPLETE_AN_ATTACK, 0);
        private CreatureCombatLogic parent;

        public AttackProgressModule(CreatureCombatLogic parent)
        {
            this.parent = parent;
        }

        public void Refresh()
        {
            progress.Current += Time.fixedDeltaTime * parent.stats.attackSpeed;
            while (progress.Current >= Constants.VALUE_TO_COMPLETE_AN_ATTACK)
            {
                progress.Current -= Constants.VALUE_TO_COMPLETE_AN_ATTACK;
                //Attack()
            }
        }
    }

    public class ValuePair
    {
        //Fields
        public float max;
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

        public ValuePair(float max, float current)
        {
            this.max = max;
            this.current = current;
        }
    }

}