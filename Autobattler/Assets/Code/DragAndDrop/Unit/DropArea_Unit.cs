using System;
using Autobattler.Grid.ManagementState;
using Autobattler.Units;
using UnityEngine;

namespace Autobattler.DragAndDrop.Unit
{
    [RequireComponent(typeof(Slot_U_View))]
    public class DropArea_Unit : DropArea<UnitView>
    {
        public Slot_U_View slotView;


        private void Awake()
        {
            slotView = GetComponent<Slot_U_View>();
        }

        public override void OnItemDropped(UnitView view)
        {
            slotView.AttachUnitView(view);
        }

        public override void OnItemUnnatached(UnitView view)
        {
            slotView.UnattachUnit();
        }
    }
}
