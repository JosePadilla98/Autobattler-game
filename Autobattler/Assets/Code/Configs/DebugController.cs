using System;
using UnityEngine;

namespace Autobattler.Configs
{
    [CreateAssetMenu(fileName = "DebugController", menuName = "ScriptableObjects/Config/DebugController")]
    public class DebugController : ScriptableObject
    {
        public bool dragAndDrop;
        public InventoryDebug inventory;

        [Serializable]
        public class InventoryDebug
        {
            public bool thingsAttached;
        }
    }
}