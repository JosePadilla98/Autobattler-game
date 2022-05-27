using Autobattler.Events;
using UnityEngine;

namespace Autobattler.Screens
{
    public class InventoryScreen : MonoBehaviour
    {
        public GameObject mainScreen;
        public GameEvent goToMainScreenEvent;

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                goToMainScreenEvent.Raise();
                gameObject.SetActive(false);
            }
        }
    }
}