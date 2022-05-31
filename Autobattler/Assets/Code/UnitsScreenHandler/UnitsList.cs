using System;
using Autobattler.Events;
using Autobattler.SelectionSystem;
using Autobattler.Units.Management;
using UnityEngine;

namespace Autobattler.UnitsScreenHandler
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

        public void OnPlayerUnitCreated(Unit unit)
        {
            var slot = AddNewSlot();
            var unitView = Instantiate<UnitView>(playerUnitPrefab, slot.transform);
            unitView.InyectDependences(unit, canvas);
        }

        private UnitsList_Slot AddNewSlot()
        {
            UnitsList_Slot slot = Instantiate<UnitsList_Slot>(slotPrefab, slotsParent);
            slot.InyectDependencies(canvas);

            return slot;
        }
    }
}