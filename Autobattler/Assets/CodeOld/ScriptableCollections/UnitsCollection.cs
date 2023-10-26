using System.Collections.Generic;
using AutobattlerOld.Units;
using AutobattlerOld.Units.Management;
using UnityEngine;

namespace AutobattlerOld.ScriptableCollections
{
    [CreateAssetMenu(fileName = "UnitsCollection", menuName = "ScriptableObjects/Collections/Units")]
    public class UnitsCollection : ScriptableObject
    {
        private List<Unit> collection;

        public List<Unit> Collection
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