using UnityEngine;

namespace Autobattler.Units.Management
{
    [CreateAssetMenu(fileName = "LevelsBonificationsModel", menuName = "ScriptableObjects/ExpSystem/LevelsBonifications")]
    public class LevelsBonificationsModel : ScriptableObject
    {
        public LevelBonifications[] LevelsBonifications;
    }
}