﻿using System;
using Autobattler.Configs;
using Autobattler.DragAndDrop;
using Autobattler.Events;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Autobattler.Screens
{
    public class InventoryScreen : MonoBehaviour
    {
        [SerializeField]
        public GameObject mainScreen;

        [Header("Events")]
        [SerializeField]
        private GameEvent_Action goToUnitsScreen;
        [SerializeField]
        private GameEvent goToMainScreen;
        [SerializeField]
        private GameEvent comeBackHere;

        private Action comeBackHereAction;
        private void Awake()
        {
            comeBackHereAction = () => comeBackHere.Raise();
        }

        #region INPUT

        public void Input_GoToMainScreen(InputAction.CallbackContext context)
        {
            if (!context.performed)
                return;

            GoToMainScreen();
        }


        public void Input_GoToUnitsList(InputAction.CallbackContext context)
        {
            if (!context.performed)
                return;

            GoToUnitsListScreen();
        }

        #endregion


        public void GoToUnitsListScreen()
        {
            goToUnitsScreen.Raise(comeBackHereAction);
            gameObject.SetActive(false);
            ObjectBeingDragged.CancelDragging();
        }

        public void GoToMainScreen()
        {
            goToMainScreen.Raise();
            gameObject.SetActive(false);
            ObjectBeingDragged.CancelDragging();
        }
    }
}