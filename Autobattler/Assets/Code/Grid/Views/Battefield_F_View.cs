using Autobattler.Grid.Generic;
using Autobattler.Units;
using Autobattler.Units.Combat;
using Autobattler.Units.Combat.View;
using UnityEngine;

namespace Autobattler.Grid.Views
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