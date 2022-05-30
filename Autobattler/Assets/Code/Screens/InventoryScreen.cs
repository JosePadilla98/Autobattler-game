using System;
using Autobattler.Events;
using UnityEngine;

namespace Autobattler.Screens
{
    public class InventoryScreen : MonoBehaviour
    {
        public GameObject mainScreen;
        public ControlsConfig controlsConfig;

        [Header("Events")]
        public GameEvent_Action goToUnitsScreen;
        public GameEvent goToMainScreen;
        public GameEvent comeBackHere;

        private Action comeBackHereAction;
        private void Awake()
        {
            comeBackHereAction = () => comeBackHere.Raise();
        }

        public void Update()
        {
            if (Input.GetKeyDown(controlsConfig.openInventory))
            {
                goToMainScreen.Raise();
                gameObject.SetActive(false);
            }

            if (Input.GetKeyDown(controlsConfig.openUnitsList))
            {
                goToUnitsScreen.Raise(comeBackHereAction);
                gameObject.SetActive(false);
            }
        }
    }
}