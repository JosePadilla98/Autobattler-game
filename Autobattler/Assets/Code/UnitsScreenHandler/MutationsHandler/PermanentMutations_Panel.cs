using System;
using System.Collections.Generic;
using Autobattler.Events;
using Autobattler.InfoPanel;
using Autobattler.MutationsSystem;
using Autobattler.MutationsSystem.Mutations;
using Autobattler.Units.Management;
using UnityEngine;

namespace Autobattler.UnitsScreenHandler
{
    public class PermanentMutations_Panel : Mutations_BasePanel
    {
        protected override List<Mutation> GetMutationList(Unit unit)
        {
            return unit.permanentMutations;
        }
    }
}