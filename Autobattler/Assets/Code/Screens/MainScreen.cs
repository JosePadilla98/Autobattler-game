using System;
using Autobattler.Configs;
using Autobattler.Events;
using Autobattler.GameControllers;
using UnityEngine;

namespace Autobattler.Screens
{
    public class MainScreen : MonoBehaviour
    {
        [SerializeField]
        private RunController runController;

        [Header("Events")]
        [SerializeField]
        private GameEvent openInventory;
        [SerializeField]
        private GameEvent_Action openUnitsScreen;
        [SerializeField]
        private GameEvent comeBackHere;

        [Header("Keys")]
        [SerializeField]
        private Key openInventoryKey;
        [SerializeField]
        private Key openUnitListKey;

        private Action comeBackHereAction;

        private void Awake()
        {
            comeBackHereAction = () => comeBackHere.Raise();
        }

        public void InitCombat()
        {
            gameObject.SetActive(false);
            runController.InitCombat();
        }

        public void Update()
        {
            if (Input.GetKeyDown(openInventoryKey.key))
            {
                openInventory.Raise();
                gameObject.SetActive(false);
            }

            if (Input.GetKeyDown(openUnitListKey.key))
            {
                openUnitsScreen.Raise(comeBackHereAction);
                gameObject.SetActive(false);
            }
        }
    }
}