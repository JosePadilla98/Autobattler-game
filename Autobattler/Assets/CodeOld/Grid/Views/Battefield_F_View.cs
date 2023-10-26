using AutobattlerOld.Grid.Generic;
using AutobattlerOld.Units;
using AutobattlerOld.Units.Combat;
using AutobattlerOld.Units.Combat.View;
using UnityEngine;

namespace AutobattlerOld.Grid.Views
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