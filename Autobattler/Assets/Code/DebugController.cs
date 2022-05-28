using System;
using UnityEngine;

namespace Autobattler
{
    [CreateAssetMenu(fileName = "DebugController", menuName = "ScriptableObjects/DebugController")]
    public class DebugController : ScriptableObject
    {
        public DragAndDropDebug dragAndDrop;








        [Serializable]
        public class DragAndDropDebug
        {
            public bool unitsInGrid;
        }
    }
}