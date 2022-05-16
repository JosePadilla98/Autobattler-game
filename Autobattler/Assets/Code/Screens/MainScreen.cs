using UnityEngine;

namespace Autobattler.Screens
{
    public class MainScreen : MonoBehaviour
    {
        public GameObject combatScreen;

        public void InitCombat()
        {
            gameObject.SetActive(false);
            combatScreen.SetActive(true);
        }
    }
}