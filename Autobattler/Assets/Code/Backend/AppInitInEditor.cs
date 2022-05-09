using Assets.Code.Backend.RunLogic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Backend
{
    public class AppInitInEditor : MonoBehaviour
    {
        public AppState appState;
        public RunState runState;
        public App app;

        private void Start()
        {
            #if UNITY_EDITOR
            if(appState == AppState.MENU)
                return;

            app.NewGame();
            if (runState == RunState.COMBAT)
                app.run.StartCombat();

            #endif
        }
    }
}
