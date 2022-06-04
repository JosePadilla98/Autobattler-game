using System;
using UnityEngine;

namespace Autobattler.Screens.GameObjectMover
{
    [Serializable]
    public class GameobjectMover
    {
        [SerializeField]
        private Transform objTransform;
        [SerializeField]
        private bool samePosInNextState;
        [SerializeField]
        [Space(20)]
        private TransformInfo nextState;
       
        private TransformInfo initialState;

        public void Init()
        {
            initialState = new TransformInfo(objTransform.parent, objTransform.localPosition);

            if(samePosInNextState)
                nextState.position = objTransform.position;
        }

        public void EnableState1()
        {
            objTransform.SetParent(initialState.parent);
            objTransform.localPosition = initialState.position;
        }

        public void EnableState2()
        {
            objTransform.SetParent(nextState.parent);

            if(samePosInNextState)
                objTransform.position = nextState.position;
            else
                objTransform.localPosition = nextState.position;
        }

        [Serializable]
        public struct TransformInfo
        {
            public Transform parent;
            public Vector3 position;

            public TransformInfo(Transform parent, Vector3 position)
            {
                this.parent = parent;
                this.position = position;
            }
        }
    }
}