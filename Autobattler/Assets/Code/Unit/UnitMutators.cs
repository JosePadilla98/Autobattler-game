using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auttobattler.Mutators
{
    public interface IUnitMutator
    {
        public string GetMutatorName();
        public Sprite GetMutatorSprite();
    }

    public abstract class UnitMutator : ScriptableObject
    {
        [SerializeField]
        private string mutName;
        [SerializeField]
        private Sprite sprite;

        public string MutationName { get => mutName; }
        public Sprite Sprite { get => sprite; }
    }
}
