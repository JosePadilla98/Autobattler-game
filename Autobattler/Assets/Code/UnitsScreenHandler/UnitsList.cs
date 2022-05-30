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

        private void AddNewSlot()
        {
            UnitsList_Slot slot = Instantiate<UnitsList_Slot>(slotPrefab, slotsParent);
            slot.InyectDependencies(canvas);
        }
    }
}