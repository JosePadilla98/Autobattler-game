using System;
using UnityEngine;

namespace Auttobattler.Backend
{
    public enum AppState { MENU, RUN }

    public class App : MonoBehaviour
    {
        private AppState state = AppState.MENU;
        private Run run;
        public Run Run
        {
            get
            {
                if (state == AppState.MENU)
                    throw new Exception("There is no run active right now");

                return run;
            }
        }

        private static App instance;
        public static App Instance { get => instance; }

        private void Awake()
        {
            instance = this;
        }

        public void NewGame()
        {
            ChangeState(AppState.RUN);
            run.Init();
        }

        private void FixedUpdate()
        {
            if (state == AppState.RUN)
                run.Refresh();
        }

        public void ChangeState(AppState state)
        {
            switch (state)
            {
                case AppState.MENU:
                    state = AppState.MENU;
                    break;

                case AppState.RUN:
                    state = AppState.RUN;
                    break;
            }
        }

       
    }
}
