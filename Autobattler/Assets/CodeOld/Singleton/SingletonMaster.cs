using AutobattlerOld.GameControllers.Combat;
using UnityEngine;

namespace AutobattlerOld
{
    //https://www.youtube.com/watch?v=cH-QQoNNpaI&ab_channel=FirstGearGames
    //Must be referenced in a scene int the built
    [CreateAssetMenu(fileName = "SingletonMaster", menuName = "ScriptableObjects/SingletonMaster")]
    public class SingletonMaster : SingletonScriptableObject<SingletonMaster>
    {
        [SerializeField]
        private DebugController _debugController;

        public static DebugController DebugController
        {
            get { return Instance._debugController; }
        }

        [SerializeField]
        private CombatState _combatState;

        public static CombatState CombatState
        {
            get { return Instance._combatState; }
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void InitializeOnLoat()
        {
            Debug.Log("SingletonMaster initialized");
        }
    }
}
