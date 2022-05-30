using System;
using Autobattler.Events;
using UnityEngine;

namespace Autobattler.Screens
{
    public class UnitsScreen : MonoBehaviour
    {
        public ControlsConfig controlsConfig;
        private Action comeBackToLastScreen;

        public void Update()
        {
            if (Input.GetKeyDown(controlsConfig.openUnitsList))
            {
                comeBackToLastScreen.Invoke();
                gameObject.SetActive(false);
            }
        }

        public void Enable(Action comeBackToLastScreen)
        {
            this.comeBackToLastScreen = comeBackToLastScreen;
            gameObject.SetActive(true);
        }
    }
}