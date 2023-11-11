using System;
using System.Collections.Generic;
using AutobattlerOld.ScriptableCollections;
using AutobattlerOld.Units.Management;
using UnityEngine;

namespace AutobattlerOld.InventorySystem
{
    public class Inventory : MonoBehaviour
    {
        [Header("Collections")]
        public UnitsCollection unitsInBench;
        public ItemsCollection items;

        [Header("Prefabs")]
        [SerializeField]
        private ItemView itemPrefab;

        [SerializeField]
        private UnitView playerUnitPrefab;

        [SerializeField]
        private Inventory_Slot slotPrefab;

        [Header("Scene things")]
        [Space(20)]
        public List<Inventory_Slot> slots;

        [SerializeField]
        private Transform slotsParent;
        public Canvas canvas;

        public void CheckIfAttachUnit(Unit unit)
        {
            if (unitsInBench.Collection.Contains(unit))
            {
                //Player has only change the item's cell
                return;
            }

            unitsInBench.Collection.Add(unit);
            CheckIfAddNewSlot();

            if (SingletonMaster.DebugController.inventory.elementsHandler)
                Debug.Log(unit.name + " attached in inventory");
        }

        public void UnattachUnit(Unit unit)
        {
            unitsInBench.Collection.Remove(unit);
            RemoveEmptySlot();

            if (SingletonMaster.DebugController.inventory.elementsHandler)
                Debug.Log(unit.name + " unattached in inventory");
        }

        public void CheckIfAttachItem(Item item) { }

        public void UnattachItem(Item item)
        {
            items.Collection.Remove(item);
            RemoveEmptySlot();

            if (SingletonMaster.DebugController.inventory.elementsHandler)
                Debug.Log(item.Scriptable.name + " unattached in inventory");
        }

        public void OnItemViewDestroyed(ItemView itemView)
        {
            UnattachItem(itemView.item);
        }

        public void CheckIfAddNewSlot()
        {
            if (ElementsCount() != slots.Count)
                return;

            AddNewSlot();
        }

        /// <summary>
        /// Launched when event is raised, so the item is already in the collection
        /// </summary>
        /// <param name="item"></param>
        public void OnNewItemAdded(Item item)
        {
            Inventory_Slot slotToAttachNewItem = GetFirstEmptySlot();
            ItemView itemView = Instantiate<ItemView>(itemPrefab, slotToAttachNewItem.transform);
            itemView.InyectDependencies(item);

            itemView.beforeDestroy += OnItemViewDestroyed;

            AddNewSlot();
        }

        /// <summary>
        /// Launched when event is raised, so the unit is already in the collection
        /// </summary>
        /// <param name="item"></param>
        public void OnNewPlayerUnitCreated(Unit unit)
        {
            Inventory_Slot slotToAttachUnit = GetFirstEmptySlot();
            var unitView = Instantiate<UnitView>(playerUnitPrefab, slotToAttachUnit.transform);
            unitView.InyectDependences(unit);

            AddNewSlot();
        }

        public void RemoveEmptySlot()
        {
            if (slots.Count == 1)
                return;

            var slotToRemove = GetFirstEmptySlot();
            slots.Remove(slotToRemove);
            Destroy(slotToRemove.gameObject);
        }

        private Inventory_Slot GetFirstEmptySlot()
        {
            foreach (var slot in slots)
            {
                if (!slot.HasItem)
                    return slot;
            }

            throw new Exception(
                "There is no empty slot in the inventory and you are requesting one"
            );
        }

        private void AddNewSlot()
        {
            Inventory_Slot slot = Instantiate<Inventory_Slot>(slotPrefab, slotsParent);
            slot.InyectDependencies(canvas, this);
            slots.Add(slot);

            slot.name = slots.Count.ToString();
        }

        private int ElementsCount()
        {
            return unitsInBench.Collection.Count + items.Collection.Count;
        }
    }
}
