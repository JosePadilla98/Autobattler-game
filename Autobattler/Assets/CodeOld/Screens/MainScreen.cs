using System;
using AutobattlerOld.DragAndDrop;
using AutobattlerOld.Events;
using AutobattlerOld.GameControllers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AutobattlerOld.Screens
{
    public class MainScreen : MonoBehaviour
    {
        [SerializeField]
        private RunController runController;

        [Header("Events")]
        [SerializeField]
        private GameEvent openInventory;

        [SerializeField]
        private GameEvent_Generic openInfoUnitsScreenInfo;

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

            openInfoUnitsScreenInfo.Raise(new ScreenInfo_Unit(null, comeBackHereAction));
            gameObject.SetActive(false);
            ObjectBeingDragged.CancelDragging();
        }

        #endregion
    }
}
