using UnityEngine;

namespace Auttobattler.Backend
{
    public class AppInitInEditor : MonoBehaviour
    {
        public AppState appState;
        public RunState runState;
        public App app;

        private void Start()
        {
            #if UNITY_EDITOR
            if (appState == AppState.MENU)
                return;

            app.NewGame();
            if (runState == RunState.COMBAT)
                app.Run.StartCombat();

            #endif
        }
    }
}
