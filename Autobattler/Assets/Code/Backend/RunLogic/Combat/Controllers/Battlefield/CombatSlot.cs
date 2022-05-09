using System;

namespace Auttobattler.Backend.RunLogic.Combat
{
    public class CombatSlot 
    {
        private CombatGrid parent;
        private Fighter unit;
        public Action<Fighter> OnUnitAttached;
        public Action OnUnitUnattached;
        public Side Side { get => parent.side; }
        public Fighter Unit { get => unit; }

        public CombatSlot(CombatGrid parent)
        {
            this.parent = parent;
        }

        public bool IsThereThisFighter(Fighter creature)
        {
            if (creature == null) 
                return false;

            return (this.unit == creature);
        }

        public void AttachUnit(Fighter unit)
        {
            this.unit = unit;
            OnUnitAttached(unit);
        }
    }
}
