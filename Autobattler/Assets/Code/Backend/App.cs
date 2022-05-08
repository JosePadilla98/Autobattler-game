using Assets.Code.Frontend.Run;
using UnityEngine;

namespace Assets.Code.Backend
{
    public enum AppState { MENU, RUN }

    class App : MonoBehaviour
    {
        [SerializeField]
        private AppState state;

        public Run run;

        internal void NewGame()
        {

        }

        public void ChangeState(AppState state)
        {
            switch (state)
            {
                case AppState.MENU:
                    state = AppState.MENU;
                    break;
            }
        }
    }
}
