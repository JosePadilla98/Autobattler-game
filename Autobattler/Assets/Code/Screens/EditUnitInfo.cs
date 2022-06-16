using System;
using Autobattler.Units.Management;

namespace Autobattler.Screens
{
    public struct EditUnitInfo
    {
        public Unit unit;
        public Action onClose;

        public EditUnitInfo(Unit unit, Action onClose)
        {
            this.unit = unit;
            this.onClose = onClose;
        }
    }
}