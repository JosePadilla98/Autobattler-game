using System;
using Autobattler.Configs;
using Autobattler.Events;
using UnityEngine;
using UnityEngine.Events;

namespace Autobattler.SelectionSystem
{
    public class InputCapturers : MonoBehaviour
    {
        [SerializeField]
        private InputCapturer[] capturers;

        private void Update()
        {
            foreach (var capturer in capturers)
            {
                if (Input.GetKeyDown(capturer.GetKey))
                {
                    capturer.gameEvent.Invoke();
                }
            }
        }

        [Serializable]
        private class InputCapturer
        {
            [SerializeField]
            private KeyModel keyModelModel;
            public UnityEvent gameEvent;

            public KeyCode GetKey => keyModelModel.key;
        }
    }
}