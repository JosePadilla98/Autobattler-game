using UnityEngine;

namespace Autobattler.Configs
{
    [CreateAssetMenu(fileName = "Color", menuName = "ScriptableObjects/Config/Color")]
    public class ColorModel : ScriptableObject
    {
        public Color color = new Color(0,0,0,1);
    }
}
