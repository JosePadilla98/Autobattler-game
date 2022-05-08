using Auttobattler.Combat;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auttobattler.MutationsSystem
{
    public abstract class MutationModel : ScriptableObject
    {
        [SerializeField]
        protected string mutationName;
        [SerializeField]
        protected Sprite sprite;
        [SerializeField]
        protected bool canBeDisabledByPlayer;
        [SerializeField]
        protected bool canBeStacked;

        public string GetName()
        {
            return mutationName;
        }

        public abstract void ModifyStats(Stats stats);

        public abstract void UnmodifyStats(Stats stats);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="order">The mutation instance index in the unit's collection. Some mutations need to know this (see the chargerSystem)</param>
        /// <param name="key">The mutation instance ID of a fighter</param>
        /// <param name="unit"></param>
        public abstract void AttachToCombatModules(int order, int key, Fighter unit);
       
        public abstract void UnattachToCombatModules(int key, Fighter unit);

    }

    public class Mutation : IMutation
    {
        private int key;
        private MutationModel model;
        public MutationModel Model { get => model; }

        public Mutation(MutationModel model)
        {
            this.model = model;
            key = UniqueKeysDispenser.GetNewKey();
        }

        public string GetName()
        {
            throw new NotImplementedException();
        }

        public void ModifyStats(Stats stats)
        {
            throw new NotImplementedException();
        }

        public void UnmodifyStats(Stats stats)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="order">This mutation instance index in the unit's collection. Some mutations need to know this (see the chargerSystem)</param>
        /// <param name="key">This instance key (ID)</param>
        /// <param name="unit"></param>
        public void AttachToCombatModules(int order ,int key, Fighter unit)
        {
            model.AttachToCombatModules(order, key, unit);
        }

        public void UnattachToCombatModules(int key, Fighter unit)
        {
            throw new NotImplementedException();
        }

        #region POOL

        #endregion
    }

    public interface IMutation
    {
        public string GetName();
        public void ModifyStats(Stats stats);
        public void UnmodifyStats(Stats stats);

        public void AttachToCombatModules(int order, int key, Fighter unit);
        public void UnattachToCombatModules(int key, Fighter unit);
    }
}
