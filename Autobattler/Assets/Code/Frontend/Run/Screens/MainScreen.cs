using Auttobattler.Backend;
using UnityEngine;

namespace Auttobattler.Frontend
{
    [ExecuteInEditMode]
    class MainScreen : MonoBehaviour, Screen
    {
        private App app;

#if UNITY_EDITOR
        private void OnEnable()
        {
            var initializer = GameObject.Find("GameManager").gameObject.GetComponent<AppInitInEditor>();
            initializer.appState = AppState.RUN;
            initializer.runState = RunState.MANAGEMENT;
        }
#endif

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
