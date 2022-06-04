using Autobattler.ScriptableCollections;
using Autobattler.Units;
using Autobattler.Units.Management;
using UnityEngine;

namespace Autobattler.Grid.Views
{
    public class Battefield_U_View : MonoBehaviour
    {
        public UnitView unitViewPrefab;
        public UnitView playerUnitViewPrefab;
        public Canvas canvas;

        public UnitsCollection playerUnitsInGrid; 
    }
}