using System;
using System.Collections.Generic;
using Autobattler.MutationsSystem.Mutations;

namespace Autobattler.Units
{
    public class _Unit : ICloneable
    {
        public String name = "NoName";
        public List<Mutation> baseMutations;
        public List<Mutation> disabledMutations;
        public List<Mutation> enabledMutations;
        public Stats stats;

        public _Unit()
        {
            stats = new Stats();
            baseMutations = new List<Mutation>();
            enabledMutations = new List<Mutation>();
            disabledMutations = new List<Mutation>();
        }

        public _Unit(UnitBuild blueprint) : this()
        {
            foreach (var mutationModel in blueprint.mutations) 
                AddNewMutation(new Mutation(mutationModel));

            foreach (var mutationModel in blueprint.mutations) 
                AddNewMutation(new Mutation(mutationModel));
        }

        public object Clone()
        {
            var clone = (_Unit)MemberwiseClone();
            return clone;
        }

        public Fighter BuildCombatInstance()
        {
            return new Fighter(this);
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