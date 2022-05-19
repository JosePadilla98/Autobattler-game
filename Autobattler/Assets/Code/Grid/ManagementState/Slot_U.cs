using System;
using Autobattler.Grid.Generic;
using Autobattler.Units;
using UnityEngine;

namespace Autobattler.Grid.ManagementState
{
    [CreateAssetMenu(fileName = "Slot_U", menuName = "ScriptableObjects/Grids/_Unit/Container")]
    public class Slot_U : ItemContainer<_Unit>
    {
        public override void AttachItem(_Unit item)
        {
            base.AttachItem(item);
        }

        public override void UnnatachItem()
        {
            base.UnnatachItem();
        }
    }
}