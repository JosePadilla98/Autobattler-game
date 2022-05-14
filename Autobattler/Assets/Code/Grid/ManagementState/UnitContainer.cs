using System;
using Autobattler.Assets.Code.Grid.ManagementState;
using Autobattler.Grid.Generic;
using Autobattler.Units;
using UnityEngine;
using UnityEngine.Animations;

namespace Autobattler.Grid
{
    [CreateAssetMenu(fileName = "UnitContainer", menuName = "ScriptableObjects/Grids/_Unit/Container")]
    public class UnitContainer : ItemContainer<Unit>
    {
        [NonSerialized]
        private Grid_U parent; 

        public void Init(Grid_U parent)
        {
            this.parent = parent;
        }
    }
}