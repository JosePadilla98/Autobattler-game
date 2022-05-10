using Auttobattler.Backend;
using UnityEngine;

namespace Auttobattler.Frontend
{
    public enum ScreensNames
    {
        MENU, MANAGEMENT, INVENTORY, FIGHTERS, COMBAT
    }

    class ScreensController : MonoBehaviour
    {
        [SerializeField]
        private Screen menuScreen;
        [SerializeField]
        private Screen managementScreen;
        [SerializeField]
        private Screen combatScreen;

        private Screen[] screens;
        private Screen currentActiveScreen;

        private void Awake()
        {
            screens = new Screen[] {
                menuScreen,
                managementScreen,
                combatScreen,
            };

            DisableAllScreens();
        }

        private void DisableAllScreens()
        {
            foreach (var screen in screens)
            {
                screen.GetGameObject().SetActive(false);
            }
        }

        private void EnableScreen(ScreensNames screensName)
        {
            currentActiveScreen.GetGameObject().SetActive(false);

            switch (screensName)
            {
                case ScreensNames.MENU:
                    currentActiveScreen = menuScreen;
                    break;

                case ScreensNames.MANAGEMENT:
                    currentActiveScreen = managementScreen;
                    break;

                case ScreensNames.COMBAT:
                    currentActiveScreen = combatScreen;
                    break;
            }

            currentActiveScreen.GetGameObject().SetActive(true);
        }
    }

    interface Screen
    {
        public void Init(App app);

        public GameObject GetGameObject();
    }
}
