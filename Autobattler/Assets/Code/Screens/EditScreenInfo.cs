using System;
using Autobattler.Units.Management;

namespace Autobattler.Screens
{
    public struct EditScreenInfo
    {
        public Unit unitToEdit;
        public Action onClose;

        public EditScreenInfo(Unit unitToEdit, Action onClose)
        {
            this.unitToEdit = unitToEdit;
            this.onClose = onClose;
        }
    }
}