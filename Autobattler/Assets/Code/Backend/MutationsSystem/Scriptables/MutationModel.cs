using Auttobattler.Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auttobattler.MutationsSystem
{
    public abstract class MutationModel : ScriptableObject, IMutation
    {
        [SerializeField]
        protected string name;
        [SerializeField]
        protected Sprite sprite;
        [SerializeField]
        protected bool canPlayerNotUseIt;

        public string GetName()
        {
            throw new System.NotImplementedException();
        }

        public void AttachToCombatModules(UnitCombatInstance unit)
        {
            throw new System.NotImplementedException();
        }

        public void ModifyStats(Stats stats)
        {
            throw new System.NotImplementedException();
        }

        public void UnattachToCombatModules(UnitCombatInstance unit)
        {
            throw new System.NotImplementedException();
        }

        public void UnmodifyStats(Stats stats)
        {
            throw new System.NotImplementedException();
        }
    }

    public class Mutation
    {
        private int key;
        private MutationModel model;
        public MutationModel Model { get => model; }

        public Mutation(MutationModel model)
        {
            this.model = model;
            key = UniqueKeysDispenser.GetNewKey();
        }

        public int GetKey()
        {
            return key;
        }
    }

    public interface IMutation
    {
        public string GetName();
        public void ModifyStats(Stats stats);
        public void UnmodifyStats(Stats stats);

        public void AttachToCombatModules(UnitCombatInstance unit);
        public void UnattachToCombatModules(UnitCombatInstance unit);
    }
}
