using Autobattler.Events;
using UnityEngine;

namespace Autobattler.Screens
{
    public class InventoryScreen : MonoBehaviour
    {
        public GameObject mainScreen;
        public GameEvent goToMainScreen;

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                goToMainScreen.Raise();
                gameObject.SetActive(false);
            }
        }
    }
}