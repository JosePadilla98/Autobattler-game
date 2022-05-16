using System;
using Autobattler.Grid.Generic;
using Autobattler.ScriptableCollections;
using Autobattler.Units;
using UnityEngine;

namespace Autobattler.Grid.ManagementState
{
    public class Battefield_F_View : MonoBehaviour
    {
        public FighterView fighterViewPrefab;
        [SerializeField]
        private ManagementStateData managementData;

        [SerializeField]
        private GridsController<Fighter> battlefield;

        public void ConvertUnitsIntoFighters()
        {

        }
    }

    [Serializable]
    class ManagementStateData
    {
        [SerializeField]
        private GridsController<Unit> managementBattlefield;
        [SerializeField]
        private UnitsCollection enemies;
        [SerializeField]
        private UnitsCollection playerUnits;
    }
}