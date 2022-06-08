using System;
using Autobattler.Configs;
using Autobattler.DragAndDrop;
using Autobattler.Events;
using UnityEngine;

namespace Autobattler.Screens
{
    public class InventoryScreen : MonoBehaviour
    {
        [SerializeField]
        public GameObject mainScreen;
        [SerializeField]
        private KeyModel openInventoryKeyModel;
        [SerializeField]
        private KeyModel openUnitListKeyModel;

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

        public void Update()
        {
            if (Input.GetKeyDown(openInventoryKeyModel.key))
            {
                GoToMainScreen();
            }

            if (Input.GetKeyDown(openUnitListKeyModel.key))
            {
                goToUnitsScreen.Raise(comeBackHereAction);
                gameObject.SetActive(false);
                ObjectBeingDragged.CancelDragging();
            }
        }

        public void GoToMainScreen()
        {
            Debug.Log("hola");
            goToMainScreen.Raise();
            gameObject.SetActive(false);
            ObjectBeingDragged.CancelDragging();
        }
    }
}