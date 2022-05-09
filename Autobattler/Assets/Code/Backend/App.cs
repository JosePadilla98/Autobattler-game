using Assets.Code.Backend.RunLogic;
using Assets.Code.Frontend;
using Assets.Code.Frontend.Run;
using Assets.Code.Frontend.Run.Screens;
using Assets.Code.Frontend.Run.Screens.CombatScreen;
using System;
using UnityEngine;

namespace Assets.Code.Backend
{
    public enum AppState { MENU, RUN }

    public class App : MonoBehaviour
    {
        private AppState state = AppState.MENU;
        public Run run;

        public void NewGame()
        {
            ChangeState(AppState.RUN);
            run.Init();
        }

        private void FixedUpdate()
        {
            if(state == AppState.RUN)
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
