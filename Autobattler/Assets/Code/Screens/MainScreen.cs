using System;
using Autobattler.Configs;
using Autobattler.DragAndDrop;
using Autobattler.Events;
using Autobattler.GameControllers;
using UnityEngine;
using UnityEngine.InputSystem;

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

        #region INPUT

        public void Input_GoToInventory(InputAction.CallbackContext context)
        {
            if (!context.performed)
                return;

            openInventory.Raise();
            gameObject.SetActive(false);
            ObjectBeingDragged.CancelDragging();
        }

        public void Input_GoToUnits(InputAction.CallbackContext context)
        {
            if (!context.performed)
                return;

            openUnitsScreen.Raise(comeBackHereAction);
            gameObject.SetActive(false);
            ObjectBeingDragged.CancelDragging();
        }

        #endregion
    }
}