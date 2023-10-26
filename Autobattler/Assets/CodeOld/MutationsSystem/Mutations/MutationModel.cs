using AutobattlerOld.Configs;
using AutobattlerOld.Configs.Color;
using AutobattlerOld.Units;
using AutobattlerOld.Units.Combat;
using AutobattlerOld.Units.Management;
using UnityEngine;

namespace AutobattlerOld.MutationsSystem.Mutations
{
    public abstract class MutationModel : ScriptableObject
    {
        [SerializeField]
        protected StatsColorsConfig colorsConfig;

        public bool canBeDisabledByPlayer;
        public StackBehaviourTypes stackBehaviourTypes;
        public Sprite sprite;

        public string Name() => name;

        public virtual string GetDescription(int timesStaked)
        {
            return "Not implemented";
        }
    }

    public enum StackBehaviourTypes
    {
        NONE,
        CAN_BE_STACKED,
        CAN_BE_OWN_MULTIPLE_TIMES
    }
}