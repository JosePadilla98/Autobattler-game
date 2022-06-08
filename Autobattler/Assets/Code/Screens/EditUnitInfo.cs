using System;
using Autobattler.Units.Management;

namespace Autobattler.Screens
{
    public struct EditUnitInfo
    {
        public Unit unitToEdit;
        public Action onClose;

        public EditUnitInfo(Unit unitToEdit, Action onClose)
        {
            this.unitToEdit = unitToEdit;
            this.onClose = onClose;
        }
    }
}