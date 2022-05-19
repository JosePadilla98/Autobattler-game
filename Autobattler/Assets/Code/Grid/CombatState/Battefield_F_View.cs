using Autobattler.Grid.Generic;
using Autobattler.Units;
using UnityEngine;

namespace Autobattler.Grid.CombatState
{
    public class Battefield_F_View : MonoBehaviour
    {
        public FighterView fighterViewPrefab;

        [SerializeField]
        private GridsController<Fighter> battlefield;

        public void ConvertUnitsIntoFighters()
        {

        }
    }

    
}