using System.Collections.Generic;
using Autobattler.Events;
using Autobattler.Units.Management;
using UnityEngine;

namespace Autobattler.UnitsListScreen
{
    public class UnitsList : MonoBehaviour
    {
        [SerializeField]
        private UnitView playerUnitPrefab;
        [SerializeField]
        private UnitsList_Slot slotPrefab;
        [SerializeField]
        private Transform slotsParent;
        [SerializeField]
        private Canvas canvas;
        [SerializeField]
        private GameEvent_Unit onUnitSelectedEvent;

        public List<UnitView> unitViews = new();

        public void OnPlayerUnitCreated(Unit unit)
        {
            var slot = AddNewSlot();
            var unitView = Instantiate<UnitView>(playerUnitPrefab, slot.transform);
            unitView.InyectDependences(unit);

            unitViews.Add(unitView);
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
           Unit unit = slot.getItemContained<UnitView>().unit;
           onUnitSelectedEvent.Raise(unit);
        }

        public void Refresh()
        {
            foreach (var unitView in unitViews)
            {
                unitView.Refresh();
            }
        }
    }
}