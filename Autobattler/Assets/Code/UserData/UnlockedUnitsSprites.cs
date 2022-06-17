using System.Collections.Generic;
using UnityEngine;

namespace Autobattler.UserData
{
    [CreateAssetMenu(fileName = "UnlockedUnitsSprites", menuName = "ScriptableObjects/UnlockedSprites")]
    public class UnlockedUnitsSprites : ScriptableObject
    {
        public List<Sprite> sprites;
    }
}
