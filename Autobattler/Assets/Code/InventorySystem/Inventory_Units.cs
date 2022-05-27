using System.Collections.Generic;
using Autobattler.DragAndDrop.Unit;
using Autobattler.ScriptableCollections;
using Autobattler.Units;
using UnityEngine;

namespace Autobattler.InventorySystem
{
    public class Inventory_Units : MonoBehaviour
    {
        public UnitsCollection unitsInBench;
        public Inventory_Slot_Unit slotPrefab;
        public Canvas canvas;

        public List<Inventory_Slot_Unit> slots;

        public void AttachUnit(_Unit unit)
        {
            unitsInBench.Collection.Add(unit);
            AddNewSlot();
        }

        public void OnUnitUnattached(_Unit unit)
        {
            unitsInBench.Collection.Remove(unit);
            RemoveEmptySlot();
        }

        public void AddNewSlot()
        {
            Inventory_Slot_Unit slot = Instantiate<Inventory_Slot_Unit>(slotPrefab, transform);
            slot.InyectDependencies(canvas, this);
            slots.Add(slot);
        }

        public void RemoveEmptySlot()
        {
            var slotToRemove = slots[^1];
            slots.Remove(slotToRemove);
            Destroy(slotToRemove);
        }
    }
}