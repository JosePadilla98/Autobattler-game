using System.Collections.Generic;
using Autobattler.MutationsSystem.Mutations;
using Autobattler.Units.Management;

namespace Autobattler.UnitsListScreen.MutationsHandler
{
    public class PermanentMutations_Panel : Mutations_BasePanel
    {
        protected override List<Mutation> GetMutationList(Unit unit)
        {
            return unit.permanentMutations;
        }
    }
}