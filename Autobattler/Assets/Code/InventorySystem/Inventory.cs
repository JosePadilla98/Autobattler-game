using System.Collections.Generic;
using Autobattler.DragAndDrop.Unit;
using Autobattler.ScriptableCollections;
using Autobattler.Units;
using UnityEngine;

namespace Autobattler.InventorySystem
{
    public class Inventory : MonoBehaviour
    {
        public UnitsCollection unitsInBench;


        public Inventory_Slot slotPrefab;
        public Canvas canvas;
        public List<Inventory_Slot> slots;

        public void AttachUnit(_Unit unit)
        {
            if(unitsInBench.Collection.Contains(unit))
               return;

            unitsInBench.Collection.Add(unit);
            CheckToAddNewSlot();


            #if UNITY_EDITOR || DEVELOPMENT_BUILD

            if (App.DebugController != null && App.DebugController.inventory.thingsAttached)
                Debug.Log(unit.name + " attached in inventory");

            #endif
        }

        public void UnattachUnit(_Unit unit)
        {
            unitsInBench.Collection.Remove(unit);
            RemoveEmptySlot();


            #if UNITY_EDITOR || DEVELOPMENT_BUILD

            if (App.DebugController != null && App.DebugController.inventory.thingsAttached)
                Debug.Log(unit.name + " unattached in inventory");

            #endif
        }

        public void AttachItem(Item item)
        {

        }

        public void UnattachItem(Item item)
        {

        }

        public void CheckToAddNewSlot()
        {
            if(ElementsCount() != slots.Count)
                return;

            Inventory_Slot slot = Instantiate<Inventory_Slot>(slotPrefab, transform);
            slot.InyectDependencies(canvas, this);
            slots.Add(slot);
        }

        public void RemoveEmptySlot()
        {
            if(slots.Count == 1)
                return;

            var slotToRemove = slots[^1];
            slots.Remove(slotToRemove);
            Destroy(slotToRemove.gameObject);
        }

        private int ElementsCount()
        {
            return unitsInBench.Collection.Count;
        }
    }
}