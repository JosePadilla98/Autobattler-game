using System;
using UnityEngine;

namespace Autobattler.Configs
{
    [CreateAssetMenu(fileName = "DebugController", menuName = "ScriptableObjects/Config/DebugController")]
    public class DebugController : ScriptableObject
    {
        public bool dragAndDrop;
        public bool unitsGridDebug;
        public InventoryDebug inventory;
        public UnitsScreenDebug unitsScreenDebug;

        [Serializable]
        public class InventoryDebug
        {
            public bool elementsHandler;
        }

        [Serializable]
        public class UnitsScreenDebug
        {
            public bool mutationsHandler;
        }
    }
}