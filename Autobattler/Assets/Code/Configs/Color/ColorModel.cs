using UnityEngine;

namespace Autobattler.Configs.Color
{
    [CreateAssetMenu(fileName = "Color", menuName = "ScriptableObjects/Config/Color")]
    public class ColorModel : ScriptableObject
    {
        public UnityEngine.Color color = new UnityEngine.Color(0,0,0,1);
    }
}
