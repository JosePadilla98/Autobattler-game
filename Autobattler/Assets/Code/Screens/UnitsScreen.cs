using System;
using Autobattler.Configs;
using Autobattler.DragAndDrop;
using Autobattler.Events;
using Autobattler.Units.Management;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Autobattler.Screens
{
    public class UnitsScreen : MonoBehaviour
    {

        [Header("Events")]
        [SerializeField]
        private GameEvent openInventoryEvent;
        [SerializeField]
        private GameEvent goToMainScreenEvent;
        [SerializeField]
        private GameEvent_Generic editUnitEvent;

        [Space(20)]
        [SerializeField]
        public UnityEvent<Unit> OnRefreshItems;

        private Action comeBackToLastScreen;
        private Unit attachedUnit;

        public void Enable(Action comeBackToLastScreen)
        {
            this.comeBackToLastScreen = comeBackToLastScreen;
            gameObject.SetActive(true);
        }

        public void AttachUnit(Unit unit)
        {
            attachedUnit = unit;
            RefreshItems();
        }

        public void RefreshItems()
        {
            OnRefreshItems?.Invoke(attachedUnit);
        }

        #region INPUT

        public void Input_GoToMainScreen(InputAction.CallbackContext context)
        {
            if (!context.performed)
                return;

            goToMainScreenEvent.Raise();
            gameObject.SetActive(false);
            ObjectBeingDragged.CancelDragging();
        }


        public void Input_Inventory(InputAction.CallbackContext context)
        {
            if (!context.performed)
                return;

            openInventoryEvent.Raise();
            gameObject.SetActive(false);
            ObjectBeingDragged.CancelDragging();
        }

        public void Input_Close(InputAction.CallbackContext context)
        {
            if (!context.performed)
                return;

            ComebackToLastScreen();
        }

        #endregion

        public void ComebackToLastScreen()
        {
            comeBackToLastScreen.Invoke();
            gameObject.SetActive(false);
            ObjectBeingDragged.CancelDragging();
        }

        public void ComeBackHere()
        {
            gameObject.SetActive(true);
            RefreshItems();
            ObjectBeingDragged.CancelDragging();
        }

        public void GoToEditScreen()
        {
            editUnitEvent.Raise(new EditUnitInfo(attachedUnit, ComeBackHere));
        }
    }
}