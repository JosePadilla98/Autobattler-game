using System;
using Autobattler.Grid;
using UnityEngine;

namespace Autobattler.Screens
{
    public class GameobjectMover : MonoBehaviour
    {
        public Transform obj;

        private TransformInfo initialState;
        public TransformInfo nextState;

        private void Awake()
        {
            var t = obj.transform;
            initialState = new TransformInfo(t.parent, t.localPosition);

            nextState.position = t.position;
        }

        public void EnableState1()
        {
            obj.SetParent(initialState.parent);
            obj.localPosition = initialState.position;
        }

        public void EnableState2()
        {
            obj.SetParent(nextState.parent);
            obj.position = nextState.position;
        }

        [Serializable]
        public struct TransformInfo
        {
            public Transform parent;
            [HideInInspector]
            public Vector3 position;

            public TransformInfo(Transform parent, Vector3 position)
            {
                this.parent = parent;
                this.position = position;
            }
        }
    }
}