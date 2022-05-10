using Auttobattler.Backend;
using UnityEngine;

namespace Auttobattler.Frontend
{
    [ExecuteInEditMode]
    class MenuScreen : MonoBehaviour, Screen
    {
        private App app;

#if UNITY_EDITOR
        private void OnEnable()
        {
            var initializer = GameObject.Find("GameManager").gameObject.GetComponent<AppInitInEditor>();
            initializer.appState = AppState.MENU;
            initializer.runState = RunState.NONE;
        }
#endif

        public void NewGame()
        {
            app.NewGame();
        }

        public void Init(App app)
        {
            this.app = app;
        }

        public GameObject GetGameObject()
        {
            return gameObject;
        }
    }
}
