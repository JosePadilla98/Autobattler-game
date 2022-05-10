using Auttobattler.Backend;
using UnityEngine;

namespace Auttobattler.Frontend
{
    [ExecuteInEditMode]
    class CombatScreen : MonoBehaviour, Screen
    {
        private App app;

#if UNITY_EDITOR
        private void OnEnable()
        {
            var initializer = GameObject.Find("GameManager").gameObject.GetComponent<AppInitInEditor>();
            initializer.appState = AppState.RUN;
            initializer.runState = RunState.COMBAT;
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
