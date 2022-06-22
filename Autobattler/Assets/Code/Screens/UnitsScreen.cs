using System;
using Autobattler.Configs;
using Autobattler.DragAndDrop;
using Autobattler.Events;
using Autobattler.Units.Management;
using Autobattler.UnitsListScreen;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Autobattler.Screens
{
    public class UnitsScreen : MonoBehaviour
    {
        [SerializeField] 
        private UnitsSelectionController unitsSelectionController;

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

        private ScreenInfo_Unit inputInfo;
        public Unit AttachedUnit => inputInfo.unit;

        public void Enable(object obj)
        {
            var info = (ScreenInfo_Unit)obj;
            inputInfo = info;
            gameObject.SetActive(true);

            SayToSelectionControllerToSelect(info.unit ?? null);
        }

        private void SayToSelectionControllerToSelect(Unit unit)
        {
            unitsSelectionController.SelectUnit(unit);
        }

        public void SelectUnit(Unit unit)
        {
            inputInfo.unit = unit;
            OnRefreshItems?.Invoke(AttachedUnit);
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
            inputInfo.onClose.Invoke();
            gameObject.SetActive(false);
            ObjectBeingDragged.CancelDragging();
        }

        public void ComeBackHere()
        {
            Enable(inputInfo);
            ObjectBeingDragged.CancelDragging();
        }

        public void GoToEditScreen()
        {
            editUnitEvent.Raise(new ScreenInfo_Unit(AttachedUnit, ComeBackHere));
        }
    }
}