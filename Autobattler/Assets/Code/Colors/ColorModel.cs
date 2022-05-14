using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Autobattler
{
    [CreateAssetMenu(fileName = "Color", menuName = "ScriptableObjects/Color")]
    public class ColorModel : ScriptableObject
    {
        public Color color = new Color(0,0,0,1);
    }
}
