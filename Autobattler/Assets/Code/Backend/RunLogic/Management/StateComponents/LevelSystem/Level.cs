using UnityEngine;

namespace Auttobattler.Backend
{
    [CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/Level", order = 3)]
    public class Level : ScriptableObject
    {
        public InvocationsData enemies;
    }

    [System.Serializable]
    public class InvocationsData
    {
        public UnitBuild[] frontColumn;
        public UnitBuild[] backColumn;
    }
}
