using UnityEngine;

namespace Auttobattler.Backend.Run.ManagementState
{
    [CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/Level", order = 3)]
    public class Level : ScriptableObject
    {
        public InvocationsData invocationsData;
    }

    [System.Serializable]
    public class InvocationsData
    {
        public UnitBuild[] frontColumn;
        public UnitBuild[] backColumn;
    }

}
