using Assets.Code.Backend;
using Assets.Code.Backend.RunLogic;
using UnityEngine;

namespace Assets.Code.Frontend.Run.Screens.CombatScreen
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
