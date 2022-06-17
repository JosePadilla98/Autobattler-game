using UnityEngine;

namespace Autobattler.ExpModule
{
    [CreateAssetMenu(fileName = "LevelsBonificationsModel", menuName = "ScriptableObjects/ExpSystem/LevelsBonifications")]
    public class UnitsLevellingModel : ScriptableObject
    {
        public LevelBonifications[] data;
    }
}