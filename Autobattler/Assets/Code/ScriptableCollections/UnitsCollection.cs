using System.Collections.Generic;
using Autobattler.Units;
using UnityEngine;

namespace Autobattler.ScriptableCollections
{
    [CreateAssetMenu(fileName = "UnitsCollection", menuName = "ScriptableObjects/Collections/Units")]
    public class UnitsCollection : ScriptableObject
    {
        private List<_Unit> collection;

        public List<_Unit> Collection
        {
            get
            {
                if (collection == null)
                    collection = new();


                return collection;
            }
        }
    }
}