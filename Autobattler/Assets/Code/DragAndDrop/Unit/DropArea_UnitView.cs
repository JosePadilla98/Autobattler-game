using System;
using Autobattler.Grid.ManagementState;
using Autobattler.Units;
using UnityEngine;

namespace Autobattler.DragAndDrop.Unit
{
    [RequireComponent(typeof(Slot_U_View))]
    public class DropArea_UnitView : DropArea<UnitView>
    {
        public Slot_U_View slotView;

        private void Awake()
        {
            slotView = GetComponent<Slot_U_View>();
        }

        public override void OnItemDropped(UnitView item)
        {
            slotView.AttachUnitView(item);
        }

        internal override void UnattachUnit()
        {
            slotView.UnattachUnit();
        }
    }
}
