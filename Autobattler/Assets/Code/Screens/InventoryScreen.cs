using Autobattler.Events;
using UnityEngine;

namespace Autobattler.Screens
{
    public class InventoryScreen : MonoBehaviour
    {
        public GameObject mainScreen;
        public GameEvent goToMainScreenEvent;
        public ControlsConfig controlsConfig;

        public void Update()
        {
            if (Input.GetKeyDown(controlsConfig.openInventory))
            {
                goToMainScreenEvent.Raise();
                gameObject.SetActive(false);
            }
        }
    }
}