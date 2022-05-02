using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auttobattler.Combat
{
    public abstract class Mutation : ScriptableObject
    {
        [SerializeField]
        private string name;
        [SerializeField]
        private Sprite sprite;

        public string MutationName { get => name; }
        public Sprite Sprite { get => sprite; }
    }
}
