using Auttobattler.Backend.MutationSystem;
using Auttobattler.Backend.RunLogic.Combat;
using System;
using System.Collections.Generic;

namespace Auttobattler.Backend.RunLogic.Management
{
    public class Unit : ICloneable
    {
        public Stats stats;

        public List<Mutation> baseMutations;
        public List<Mutation> enabledMutations;
        public List<Mutation> disabledMutations;

        public Unit()
        {
            stats = new Stats();
            baseMutations = new List<Mutation>();
            enabledMutations = new List<Mutation>();
            disabledMutations = new List<Mutation>();
        }

        public Unit(UnitBuild blueprint) : base()
        {
            foreach (var mutationModel in blueprint.mutations)
            {
                AddNewMutation(new Mutation(mutationModel));
            }

            foreach (var mutationModel in blueprint.mutations)
            {
                AddNewMutation(new Mutation(mutationModel));
            }
        }

        public Fighter BuildCombatInstance()
        {
            return new Fighter(this);
        }

        public object Clone()
        {
            var clone = (Unit)this.MemberwiseClone();
            return clone;
        }

        #region MUTATIONS COLLECTIONS HANDLER

        public void AddNewMutation(Mutation mutation)
        {
            enabledMutations.Add(mutation);
            mutation.Model.ModifyStats(stats);
        }

        public void DisableMutation(Mutation mutation)
        {
            enabledMutations.Remove(mutation);
            mutation.Model.UnmodifyStats(stats);
            disabledMutations.Add(mutation);
        }

        public void EnableMutation(Mutation mutation)
        {
            enabledMutations.Add(mutation);
            mutation.Model.ModifyStats(stats);
            disabledMutations.Remove(mutation);
        }

        #endregion
    }
}
