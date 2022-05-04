using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Auttobattler.Combat.ChargerSystem
{
    public class ChargerSystem
    {
        private Dictionary<int, ChargeableItem> items = new Dictionary<int, ChargeableItem>();

        public void AddItem(float physicalSpeedFactor, float magicalSpeedFactor, float duration, Action OnRecharged)
        {
            ChargeableItem item = ItemPools.Pool.Get();
            item.Inflate(physicalSpeedFactor, magicalSpeedFactor, duration, OnRecharged);
        }

        public void RemoveItem(int key)
        {
            ChargeableItem item;
            items.Remove(key, out item);
            ItemPools.Pool.Release(item);
        }

        public void Refresh(Stats stats)
        {
            foreach (var item in items.Values)
            {
                item.Refresh(stats);
            }
        }
    }

    internal class ItemPools
    {
        public static ObjectPool<ChargeableItem> Pool { get => pool; }
       
        private static ObjectPool<ChargeableItem> pool = new ObjectPool<ChargeableItem>(() => new ChargeableItem());
    }

    internal class ChargeableItem
    {
        private float physicalSpeedFactor;
        private float magicalSpeedFactor;
        private float duration;

        private float progress;
        private Action OnRecharged;

        public void Inflate(float physicalSpeedFactor, float magicalSpeedFactor, float duration, Action OnRecharged)
        {
            this.physicalSpeedFactor = physicalSpeedFactor;
            this.magicalSpeedFactor = magicalSpeedFactor;
            this.duration = duration;
        }

        public void Refresh(Stats stats)
        {
            progress += Time.fixedDeltaTime * physicalSpeedFactor * stats.GetStat(StatsNames.PHYSICAL_SPEED);
            progress += Time.fixedDeltaTime * magicalSpeedFactor * stats.GetStat(StatsNames.MAGICAL_SPEED);

            while (progress >= duration)
            {
                progress -= duration;
                OnRecharged();
            }
        }
    }
}
