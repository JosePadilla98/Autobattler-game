using System.Collections.Generic;
using AutobattlerOld.Events;
using AutobattlerOld.ScriptableCollections;
using AutobattlerOld.Units.Management;
using UnityEngine;

namespace AutobattlerOld.UnitsListScreen
{
    public class UnitsList : MonoBehaviour
    {
        [SerializeField]
        private GameEvent_Unit onUnitSelected;

        [SerializeField]
        private UnitView playerUnitPrefab;
        [SerializeField]
        private UnitsList_Slot slotPrefab;
        [SerializeField]
        private Transform slotsParent;
        [SerializeField]
        private Canvas canvas;
        [SerializeField]
        private UnitsCollection team;

        private List<UnitsList_Slot> slots = new();

        public void OnEnable()
        {
            for (int i = 0; i < team.Collection.Count; i++)
            {
                var unit = team.Collection[i];
                AddNewUnitView(unit);
            }
        }

        private void OnDisable()
        {
            team.Collection.Clear();

            foreach (var slot in slots)
            {
                team.Collection.Add(slot.Unit);
            }

            for (int i = slots.Count - 1; i >= 0; i--)
            {
                Destroy(slots[i].gameObject);
            }

            slots.Clear();
        }

        private void AddNewUnitView(Unit unit)
        {
            var slot = AddNewSlot();
            var unitView = Instantiate<UnitView>(playerUnitPrefab, slot.transform);
            unitView.InyectDependences(unit);

            slots.Add(slot);
        }

        private UnitsList_Slot AddNewSlot()
        {
            UnitsList_Slot slot = Instantiate<UnitsList_Slot>(slotPrefab, slotsParent);
            slot.InyectDependencies(canvas);
            slot.name = "UnitsList_Slot_" + slotsParent.childCount.ToString();

            return slot;
        }

        public void OnUnitSlotSelected(MonoBehaviour unitsList_slot)
        {
            var slot = (UnitsList_Slot)unitsList_slot;
            Unit unit = slot.Unit;
            onUnitSelected.Raise(unit);
        }
    }
}