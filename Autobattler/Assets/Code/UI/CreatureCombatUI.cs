using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Auttobattler.Combat;

namespace Auttobattler
{
    public class CreatureCombatUI : MonoBehaviour
    {
        [SerializeField]
        private SliderBar healthBar;

        [SerializeField]
        private SliderBar attackProgressBar;

        private CreatureInCombat creature;
        public CreatureInCombat Creature { get => creature;}

        private void AttachCreature()
        {
            healthBar.AttachValuePair(creature.stats.health);
            attackProgressBar.AttachValuePair(creature.attackModule.progress);
        }

        private void UnattachCreature()
        {
            
        }
    }
}