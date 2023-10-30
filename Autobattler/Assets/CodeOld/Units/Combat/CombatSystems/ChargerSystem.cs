using System;
using System.Collections.Generic;
using AutobattlerOld.Units.Management;
using UnityEngine;
using UnityEngine.Pool;

namespace AutobattlerOld.Units.Combat.CombatSystems
{
    public class ChargerSystem : CombatSystem
    {
        public List<ChargeableItem> rechargingItems = new();
        private List<ChargeableItem> waitingToBeRecharged = new();

        public ChargerSystem(Fighter parent)
            : base(parent) { }

        private EnergySystem energySystem => parent.energySys;

        public void Refresh()
        {
            //Try to pay the costs of waitingToBeRecharged items, and then put it in the recharging collection
            for (var i = waitingToBeRecharged.Count - 1; i >= 0; i--)
            {
                var waitingItem = waitingToBeRecharged[i];

                if (energySystem.TryPayCost(waitingItem.Cost))
                {
                    rechargingItems.Add(waitingItem);
                    waitingToBeRecharged.RemoveAt(i);
                }
            }

            for (var i = rechargingItems.Count - 1; i >= 0; i--)
            {
                var rechargingItem = rechargingItems[i];
                rechargingItem.Refresh(parent.StatsContainer);
            }
        }

        public void AddToWaitingList(ChargeableItem item)
        {
            waitingToBeRecharged.Add(item);
            waitingToBeRecharged.Sort((a, b) => a.CompareTo(b));
        }
    }

    [Serializable]
    public struct ChargeableData
    {
        public EnergyCostData cost;
        public float physicalSpeedFactor;
        public float magicalSpeedFactor;
        public float timeToCast;

        [HideInInspector]
        /// <summary>
        ///     Mutation instance index in unit's collection
        /// </summary>
        public int priority;

        public ChargeableData(
            EnergyCostData cost,
            float physicalSpeedFactor,
            float magicalSpeedFactor,
            float timeToCast,
            int priority
        )
        {
            this.cost = cost;
            this.physicalSpeedFactor = physicalSpeedFactor;
            this.magicalSpeedFactor = magicalSpeedFactor;
            this.timeToCast = timeToCast;
            this.priority = priority;
        }
    }

    public class ChargeableItem : IComparable<ChargeableItem>
    {
        private ChargeableData data;

        public Action OnRecharged;
        private float progress;

        public float PhysicalSpeedFactor => data.physicalSpeedFactor;
        public float MagicalSpeedFactor => data.magicalSpeedFactor;
        public float TimeToCast => data.timeToCast;
        public EnergyCostData Cost => data.cost;
        public int Priority => data.priority;

        public int CompareTo(ChargeableItem other)
        {
            if (Priority > other.Priority)
                return 1;

            if (Priority < other.Priority)
                return -1;

            return 0;
        }

        public ChargeableItem Inflate(int key, ChargeableData data, Action OnRecharged)
        {
            this.data = data;
            this.OnRecharged = OnRecharged;
            return this;
        }

        public void Refresh(StatsContainer statsContainer)
        {
            progress +=
                Time.fixedDeltaTime
                * PhysicalSpeedFactor
                / 100
                * statsContainer.GetStatValue(OldStatsNames.PHYSICAL_SPEED);
            progress +=
                Time.fixedDeltaTime
                * MagicalSpeedFactor
                / 100
                * statsContainer.GetStatValue(OldStatsNames.MAGICAL_SPEED);

            while (progress >= TimeToCast)
            {
                progress -= TimeToCast;
                OnRecharged();
            }
        }

        #region POOL

        public static ObjectPool<ChargeableItem> Pool { get; } = new(() => new ChargeableItem());

        #endregion
    }
}
