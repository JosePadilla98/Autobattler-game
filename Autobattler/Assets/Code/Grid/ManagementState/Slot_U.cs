using System;
using Autobattler.Grid.Generic;
using Autobattler.Units;
using UnityEngine;

namespace Autobattler.Grid.ManagementState
{
    [CreateAssetMenu(fileName = "UnitContainer", menuName = "ScriptableObjects/Grids/_Unit/Container")]
    public class Slot_U : ItemContainer<Unit>
    {
        [NonSerialized]
        private Grid_U parent; 

        public void Init(Grid_U parent)
        {
            this.parent = parent;
        }
    }
}