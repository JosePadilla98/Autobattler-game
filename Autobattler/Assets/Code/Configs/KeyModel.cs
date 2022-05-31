using UnityEngine;

namespace Autobattler.Configs
{
    [CreateAssetMenu(fileName = "Key", menuName = "ScriptableObjects/Config/Key")]
    public class KeyModel : ScriptableObject
    {
        public KeyCode key;
    }
}