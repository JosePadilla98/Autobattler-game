using Autobattler.GameControllers;
using UnityEngine;

namespace Autobattler.Screens
{
    public class MainScreen : MonoBehaviour
    {
        public RunController runController;

        public void InitCombat()
        {
            gameObject.SetActive(false);
            runController.InitCombat();
        }
    }
}