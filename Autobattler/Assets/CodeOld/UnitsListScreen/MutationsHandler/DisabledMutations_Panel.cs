using System.Collections.Generic;
using AutobattlerOld.MutationsSystem.Mutations;
using AutobattlerOld.Units.Management;

namespace AutobattlerOld.UnitsListScreen.MutationsHandler
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