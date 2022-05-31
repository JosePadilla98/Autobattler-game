using System;
using Autobattler.Configs;
using Autobattler.Events;
using UnityEngine;

namespace Autobattler.Screens
{
    public class InventoryScreen : MonoBehaviour
    {
        [SerializeField]
        public GameObject mainScreen;
        [SerializeField]
        private Key openInventoryKey;
        [SerializeField]
        private Key openUnitListKey;

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
            if (Input.GetKeyDown(openInventoryKey.key))
            {
                goToMainScreen.Raise();
                gameObject.SetActive(false);
            }

            if (Input.GetKeyDown(openUnitListKey.key))
            {
                goToUnitsScreen.Raise(comeBackHereAction);
                gameObject.SetActive(false);
            }
        }
    }
}