using System.Collections.Generic;
using UnityEngine;

namespace AutobattlerOld.UserData
{
    [CreateAssetMenu(fileName = "UnlockedUnitsSprites", menuName = "ScriptableObjects/UnlockedSprites")]
    public class UnlockedUnitsSprites : ScriptableObject
    {
        public List<Sprite> sprites;
    }
}
