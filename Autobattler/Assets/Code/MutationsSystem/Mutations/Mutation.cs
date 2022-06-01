using System;
using Autobattler.Units.Combat;
using Autobattler.Units.Management;

namespace Autobattler.MutationsSystem.Mutations
{
    public class Mutation 
    {
        public MutationModel Model { get; }
        public String Name => Model.name;
        public String Description => Model.GetDescription(timesStacked);

        private int key;
        private int timesStacked = 1;

        public Mutation(MutationModel model)
        {
            Model = model;
            key = UniqueKeysDispenser.GetNewKey();
        }

        public void AttachToCombatModules(int order, int key, Fighter unit)
        {
            (Model as IModifyFighter).AttachToFighter(order, key, unit);
        }

        public void UnattachToCombatModules(int key, Fighter unit)
        {
            throw new NotImplementedException();
        }

        #region POOL

        #endregion
    }
}