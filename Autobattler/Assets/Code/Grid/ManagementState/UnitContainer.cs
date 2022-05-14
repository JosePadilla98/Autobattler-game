using Autobattler.Assets.Code.Grid.ManagementState;
using Autobattler.Grid.Generic;
using Autobattler.Units;
using UnityEngine;
using UnityEngine.Animations;

namespace Autobattler.Grid
{
    [CreateAssetMenu(fileName = "UnitContainer", menuName = "ScriptableObjects/UnitsGrid/UnitContainer")]
    public class UnitContainer : ItemContainer<Unit>
    {
        private Grid_U parent; 

        public void Init(Grid_U parent)
        {
            this.parent = parent;
        }
    }
}