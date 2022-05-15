using System.Collections.Generic;
using Autobattler.Units;
using UnityEngine;

namespace Autobattler.Player
{
    [CreateAssetMenu(fileName = "UnitsCollection", menuName = "ScriptableObjects/Collections/Units")]
    public class UnitsCollection : ScriptableObject
    {
        public List<Unit> collection = new();
    }
}