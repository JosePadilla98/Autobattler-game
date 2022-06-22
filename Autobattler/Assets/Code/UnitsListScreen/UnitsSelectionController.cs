using System;
using Autobattler.SelectionsSystem;
using Autobattler.Units.Management;
using UnityEngine;

namespace Autobattler.UnitsListScreen
{
    public class UnitsSelectionController : SelectionController
    {
        public void SelectUnit(Unit unit)
        {
            if (selectables.Count <= 0)
                throw new Exception("No has manejado esto");

            if (unit == null)
            {
                OnOneChildSelected(selectables[0]);
                return;
            }

            foreach (var selectable in selectables)
            {
                var unitInSelectable = (selectable.target as UnitsList_Slot).Unit;
                if (unit == unitInSelectable)
                {
                    OnOneChildSelected(selectable);
                    return;
                }
            }

            return;
        }
    }
}