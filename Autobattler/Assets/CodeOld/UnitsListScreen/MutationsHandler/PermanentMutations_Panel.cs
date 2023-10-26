using System.Collections.Generic;
using AutobattlerOld.MutationsSystem.Mutations;
using AutobattlerOld.Units.Management;

namespace AutobattlerOld.UnitsListScreen.MutationsHandler
{
    public class PermanentMutations_Panel : Mutations_BasePanel
    {
        protected override List<Mutation> GetMutationList(Unit unit)
        {
            return unit.permanentMutations;
        }
    }
}