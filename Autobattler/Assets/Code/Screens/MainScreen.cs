using System;
using Autobattler.Events;
using Autobattler.GameControllers;
using UnityEngine;

namespace Autobattler.Screens
{
    public class MainScreen : MonoBehaviour
    {
        public RunController runController;
        public ControlsConfig controlsConfig;

        [Header("Events")]
        public GameEvent openInventory;
        public GameEvent_Action openUnitsScreen;
        public GameEvent comeBackHere;

        public void InitCombat()
        {
            gameObject.SetActive(false);
            runController.InitCombat();
        }

        public void Update()
        {
            if (Input.GetKeyDown(controlsConfig.openInventory))
            {
                openInventory.Raise();
                gameObject.SetActive(false);
            }

            if (Input.GetKeyDown(controlsConfig.openUnitsList))
            {
                openUnitsScreen.Raise(() => comeBackHere.Raise());
                gameObject.SetActive(false);
            }
        }
    }
}