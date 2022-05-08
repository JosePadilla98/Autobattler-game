using Assets.Code.Backend;
using UnityEngine;

namespace Assets.Code.Frontend.Run.Screens.CombatScreen
{
    [ExecuteInEditMode]
    class CombatScreen : MonoBehaviour
    {
        [SerializeField]
        private App app;

        #if UNITY_EDITOR
        private void OnEnable()
        {

            app.ChangeState(AppState.RUN);
            app.run.ChangeState(RunState.MANAGEMENT);

        }
        #endif
    }
}
