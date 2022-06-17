using System.Collections.Generic;
using Autobattler.MutationsSystem.Mutations;
using Autobattler.Units.Management;

namespace Autobattler.UnitsListScreen.MutationsHandler
{
    public class EnabledMutations_Panel : Mutations_BasePanel
    {
        protected override List<Mutation> GetMutationList(Unit unit)
        {
            return unit.enabledMutations;
        }

        public override void LoadUnitData(Unit unitToLoad)
        {
            base.LoadUnitData(unitToLoad);
            AddNewSlot();
        }

        public override void SaveChanges()
        {
            currentUnitAttached.DisableAllMutations();

            foreach (var slot in Slots)
            {
                if (slot.HasItem)
                    currentUnitAttached.EnableMutation(slot.MutationContained);
            }
        }
        
        public override void AttachMutation(Mutation mutation)
        {
            base.AttachMutation(mutation);
            CheckIfAddNewSlot();
        }
    }
}