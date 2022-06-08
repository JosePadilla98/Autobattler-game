using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Autobattler
{
    [CreateAssetMenu(fileName = "UnlockedUnitsSprites", menuName = "ScriptableObjects/UnlockedSprites")]
    public class UnlockedUnitsSprites : ScriptableObject
    {
        public List<Sprite> sprites;
    }
}
