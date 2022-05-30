using Autobattler.Events;
using Autobattler.GameControllers;
using UnityEngine;

namespace Autobattler.Screens
{
    public class MainScreen : MonoBehaviour
    {
        public RunController runController;
        public GameEvent openInventory;
        public ControlsConfig controlsConfig;

        public void InitCombat()
        {
            gameObject.SetActive(false);
            runController.InitCombat();
        }

        public void Update()
        {
            if (Input.GetKeyDown(controlsConfig.openInventory))
            {
                openInventory.Raise();
                gameObject.SetActive(false);
            }
        }
    }
}