using System;
using UnityEngine;

namespace Autobattler
{
    [CreateAssetMenu(fileName = "DebugController", menuName = "ScriptableObjects/DebugController")]
    public class DebugController : ScriptableObject
    {
        public DragAndDropDebug dragAndDrop;
        public InventoryDebug inventory;





        [Serializable]
        public class DragAndDropDebug
        {
            public bool unitsInGrid;
        }

        [Serializable]
        public class InventoryDebug
        {
            public bool thingsAttached;
        }
    }
}