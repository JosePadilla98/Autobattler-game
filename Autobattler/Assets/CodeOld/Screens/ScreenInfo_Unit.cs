using System;
using AutobattlerOld.Units.Management;

namespace AutobattlerOld.Screens
{
    public struct ScreenInfo_Unit
    {
        public Unit unit;
        public Action onClose;

        public ScreenInfo_Unit(Unit unit, Action onClose)
        {
            this.unit = unit;
            this.onClose = onClose;
        }
    }
}