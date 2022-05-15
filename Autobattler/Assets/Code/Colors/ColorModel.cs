using UnityEngine;

namespace Autobattler.Colors
{
    [CreateAssetMenu(fileName = "Color", menuName = "ScriptableObjects/Color")]
    public class ColorModel : ScriptableObject
    {
        public Color color = new Color(0,0,0,1);
    }
}
