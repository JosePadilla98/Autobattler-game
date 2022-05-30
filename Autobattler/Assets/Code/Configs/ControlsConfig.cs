using System;
using UnityEngine;

namespace Autobattler
{
    [CreateAssetMenu(fileName = "ControlsConfig", menuName = "ScriptableObjects/ControlsConfig")]
    public class ControlsConfig : ScriptableObject
    {
        public KeyCode openInventory;
    }
}