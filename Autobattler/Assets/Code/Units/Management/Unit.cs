using System;
using System.Collections.Generic;
using Autobattler.MutationsSystem.Mutations;
using Autobattler.Units.Combat;
using UnityEngine;

namespace Autobattler.Units.Management
{
    public class Unit : ICloneable
    {
        public String name;
        public Sprite sprite;
        public StatsContainer statsContainer;
        public List<Mutation> permanentMutations;
        public List<Mutation> disabledMutations;
        public List<Mutation> enabledMutations;

        public Unit()
        {
            statsContainer = new StatsContainer();
            permanentMutations = new List<Mutation>();
            enabledMutations = new List<Mutation>();
            disabledMutations = new List<Mutation>();
        }

        public Unit(UnitBuild blueprint) : this()
        {
            name = blueprint.name;
            sprite = blueprint.sprite;

            foreach (var mutationModel in blueprint.mutations) 
                AddNewMutation(new Mutation(mutationModel));
        }

        public object Clone()
        {
            var clone = (Unit)MemberwiseClone();
            return clone;
        }

        public Fighter BuildCombatInstance()
        {
            return new Fighter(this);
        }

        #region MUTATIONS COLLECTIONS HANDLER

        public void AddNewMutation(Mutation mutation)
        {
            if (mutation.Model.canBeDisabledByPlayer)
            {
                EnableMutation(mutation);
            }
            else
            {
                AddPermanentMutation(mutation);
            }
        }

        private void AddPermanentMutation(Mutation mutation)
        {
            permanentMutations.Add(mutation);
            CheckIfModifyStats(mutation);
        }

        public void DisableMutation(Mutation mutation)
        {
            enabledMutations.Remove(mutation);
            CheckIfUnmodifyStats(mutation);
        }

        public void DisableAllMutations()
        {
            foreach (var mutation in enabledMutations)
            {
                CheckIfUnmodifyStats(mutation);
            }
            enabledMutations.Clear();
        }

        public void EnableMutation(Mutation mutation)
        {
            enabledMutations.Add(mutation);
            CheckIfModifyStats(mutation);
        }

        private void CheckIfModifyStats(Mutation mutation)
        {
            if (mutation.Model is IModifyStats)
            {
                (mutation.Model as IModifyStats).ModifyStats(statsContainer);
            }
        }

        private void CheckIfUnmodifyStats(Mutation mutation)
        {
            if (mutation.Model is IModifyStats)
            {
                (mutation.Model as IModifyStats).UnmodifyStats(statsContainer);
            }
        }

        #endregion
    }
}