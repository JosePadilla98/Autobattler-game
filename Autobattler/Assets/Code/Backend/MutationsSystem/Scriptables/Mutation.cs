using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auttobattler.MutationsSystem
{
    public abstract class Mutation : ScriptableObject, IMutation
    {
        [SerializeField]
        protected string name;
        [SerializeField]
        protected Sprite sprite;

        public string GetName()
        {
            return name;
        }

        public void AttachToUnit(Unit unit)
        {
            throw new System.NotImplementedException();
        }

        public void UnattachToUnit(Unit unit)
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IMutation
    {
        public string GetName();
        public void AttachToUnit(Unit unit);
        public void UnattachToUnit(Unit unit);
    }
}
