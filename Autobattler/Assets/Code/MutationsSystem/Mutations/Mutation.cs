using System;
using Autobattler.Units.Combat;
using Autobattler.Units.Management;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Autobattler.MutationsSystem.Mutations
{
    public class Mutation 
    {
        public MutationModel Model { get; }
        public String Name => Model.name;
        public String Description => Model.GetDescription(timesStacked);
        public Sprite Sprite => Model.sprite;

        private int key = -1;
        private int timesStacked = 1;

        public Mutation(MutationModel model)
        {
            Model = model;
            key = UniqueKeysDispenser.GetNewKey();
        }

        public void AttachToFighter(int order, Fighter unit)
        {
            if (key == -1)
                throw new Exception("Key has not been setted");

            if(Model is IModifyFighter)
                (Model as IModifyFighter).AttachToFighter(order, key, unit);
        }

        public void UnattachToFighter(int key, Fighter unit)
        {
            throw new NotImplementedException();
        }

        #region POOL

        #endregion
    }
}