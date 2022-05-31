using System;
using Autobattler.Configs;
using Autobattler.Events;
using UnityEngine;

namespace Autobattler.Screens
{
    public class UnitsScreen : MonoBehaviour
    {
        [SerializeField]
        private Key openUnitsScreenKey;

        private Action comeBackToLastScreen;

        public void Update()
        {
            if (Input.GetKeyDown(openUnitsScreenKey.key))
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