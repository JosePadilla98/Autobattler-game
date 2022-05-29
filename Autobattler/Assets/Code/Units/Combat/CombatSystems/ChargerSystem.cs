using System;
using System.Collections.Generic;
using Autobattler.Units.Management;
using UnityEngine;
using UnityEngine.Pool;

namespace Autobattler.Units.Combat.CombatSystems
{
    public class ChargerSystem : CombatSystem
    {
        public Dictionary<int, ChargeableItem> rechargingItems = new();
        private List<ChargeableItem> waiting;

        private ChargerSystem(Fighter parent) : base(parent)
        {
        }

        private EnergySystem energySystem => parent.energySys;

        public void Refresh()
        {
            //Try to pay the costs of waiting items, and then put it in the recharging collection
            for (var i = waiting.Count; i > 0; i--)
            {
                var waitingItem = waiting[i];

                if (energySystem.TryPayCost(waitingItem.Cost))
                {
                    rechargingItems.Add(waitingItem.MutationID, waitingItem);
                    waiting.RemoveAt(i);
                }
            }

            foreach (var RechargingItem in rechargingItems.Values) RechargingItem.Refresh(parent.Stats);
        }

        public void AddToWaitingList(ChargeableItem item)
        {
            waiting.Add(item);
            waiting.Sort((a, b) => a.CompareTo(b));
        }
    }

    public struct ChargeableData
    {
        public EnergyCostData cost;
        public float physicalSpeedFactor;
        public float magicalSpeedFactor;
        public float duration;
        public int mutationID;

        /// <summary>
        ///     Mutation instance index in unit's collection
        /// </summary>
        public int priority;

        public ChargeableData(EnergyCostData cost, float physicalSpeedFactor, float magicalSpeedFactor, float duration,
            int mutationID, int priority)
        {
            this.cost = cost;
            this.physicalSpeedFactor = physicalSpeedFactor;
            this.magicalSpeedFactor = magicalSpeedFactor;
            this.duration = duration;
            this.mutationID = mutationID;
            this.priority = priority;
        }
    }

    public class ChargeableItem : IComparable<ChargeableItem>
    {
        private ChargeableData data;

        private Action OnRecharged;
        private float progress;
        public float PhysicalSpeedFactor => data.physicalSpeedFactor;
        public float MagicalSpeedFactor => data.magicalSpeedFactor;
        public float Duration => data.duration;
        public EnergyCostData Cost => data.cost;
        public int Priority => data.priority;
        public int MutationID => data.mutationID;

        public int CompareTo(ChargeableItem other)
        {
            if (Priority > other.Priority)
                return 1;

            if (Priority < other.Priority)
                return -1;

            return 0;
        }

        public ChargeableItem Inflate(ChargeableData data, Action OnRecharged)
        {
            this.data = data;
            this.OnRecharged = OnRecharged;
            return this;
        }

        public void Refresh(Stats stats)
        {
            progress += Time.fixedDeltaTime * PhysicalSpeedFactor * stats.GetStatValue(StatsNames.PHYSICAL_SPEED);
            progress += Time.fixedDeltaTime * MagicalSpeedFactor * stats.GetStatValue(StatsNames.MAGICAL_SPEED);

            while (progress >= Duration)
            {
                progress -= Duration;
                OnRecharged();
            }
        }

        #region POOL

        public static ObjectPool<ChargeableItem> Pool { get; } = new(() => new ChargeableItem());

        #endregion
    }
}