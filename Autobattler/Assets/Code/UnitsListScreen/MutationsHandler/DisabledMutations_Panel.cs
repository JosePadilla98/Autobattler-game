using System.Collections.Generic;
using Autobattler.MutationsSystem.Mutations;
using Autobattler.Units.Management;

namespace Autobattler.UnitsListScreen.MutationsHandler
{
    public class DisabledMutations_Panel : Mutations_BasePanel
    {
        protected override List<Mutation> GetMutationList(Unit unit)
        {
            return unit.disabledMutations;
        }

        public override void LoadUnitData(Unit unitToLoad)
        {
            base.LoadUnitData(unitToLoad);
            AddNewSlot();
        }

        public override void AttachMutation(Mutation mutation)
        {
            base.AttachMutation(mutation);
            CheckIfAddNewSlot();
        }
    }
}