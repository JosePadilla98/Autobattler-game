using System;
using AutobattlerOld.DragAndDrop;
using AutobattlerOld.Events;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AutobattlerOld.Screens
{
    public class InventoryScreen : MonoBehaviour
    {
        [SerializeField]
        public GameObject mainScreen;

        [Header("Events")]
        [SerializeField]
        private GameEvent_Generic goToUnitsScreen;
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
            goToUnitsScreen.Raise(new ScreenInfo_Unit(null, comeBackHereAction));
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