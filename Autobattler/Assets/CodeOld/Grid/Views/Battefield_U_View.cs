using AutobattlerOld.ScriptableCollections;
using AutobattlerOld.Units;
using AutobattlerOld.Units.Management;
using UnityEngine;

namespace AutobattlerOld.Grid.Views
{
    public class Battefield_U_View : MonoBehaviour
    {
        public UnitView unitViewPrefab;
        public UnitView playerUnitViewPrefab;
        public Canvas canvas;

        public UnitsCollection playerUnitsInGrid;
    }
}