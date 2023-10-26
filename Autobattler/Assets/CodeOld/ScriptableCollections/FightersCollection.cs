using System.Collections.Generic;
using AutobattlerOld.Units;
using AutobattlerOld.Units.Combat;
using UnityEngine;

namespace AutobattlerOld.ScriptableCollections
{
    [CreateAssetMenu(fileName = "FightersCollection", menuName = "ScriptableObjects/Collections/Fighters")]
    public class FightersCollection : ScriptableObject
    {
        private List<Fighter> collection;

        public List<Fighter> Collection
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