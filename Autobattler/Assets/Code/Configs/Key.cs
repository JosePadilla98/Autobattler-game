using UnityEngine;

namespace Autobattler.Configs
{
    [CreateAssetMenu(fileName = "Key", menuName = "ScriptableObjects/Config/Key")]
    public class Key : ScriptableObject
    {
        public KeyCode key;
    }
}