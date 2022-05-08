using Assets.Code.Backend;
using UnityEngine;

namespace Assets.Code.Frontend
{
    [ExecuteInEditMode]
    class MenuScreen : MonoBehaviour
    {
        [SerializeField]
        private App app;

        #if UNITY_EDITOR
        private void OnEnable()
        {
            app.ChangeState(AppState.MENU);
            app.run.ChangeState(RunState.NONE);

        }
        #endif

        public void NewGame()
        {
            MenuScreenActions.NewGame(app);
        }
    }
}
