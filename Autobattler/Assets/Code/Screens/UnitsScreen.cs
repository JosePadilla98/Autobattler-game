using System;
using Autobattler.Configs;
using Autobattler.DragAndDrop;
using Autobattler.Events;
using Autobattler.Units.Management;
using UnityEngine;
using UnityEngine.Events;

namespace Autobattler.Screens
{
    public class UnitsScreen : MonoBehaviour
    {
        [SerializeField]
        private KeyModel openUnitsScreenKeyModel;
        [SerializeField]
        private GameEvent_Generic editUnitEvent;
        [Space(20)]
        [SerializeField]
        public UnityEvent<Unit> OnRefreshItems;

        private Action comeBackToLastScreen;
        private Unit attachedUnit;

        public void Update()
        {
            if (Input.GetKeyDown(openUnitsScreenKeyModel.key))
            {
                ComebackToLastScreen();
            }
        }

        public void Enable(Action comeBackToLastScreen)
        {
            this.comeBackToLastScreen = comeBackToLastScreen;
            gameObject.SetActive(true);
        }

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
            editUnitEvent?.Raise(new EditScreenInfo(attachedUnit, ComeBackHere));
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
    }
}