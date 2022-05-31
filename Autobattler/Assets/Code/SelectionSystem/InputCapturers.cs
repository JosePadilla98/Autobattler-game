using System;
using UnityEngine;

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

            }
        }

        [Serializable]
        private class InputCapturer
        {
            
        }
    }
}