using System;
using UnityEngine;

namespace Autobattler
{
    [CreateAssetMenu(fileName = "ControlsConfig", menuName = "ScriptableObjects/Config/Controls")]
    public class ControlsConfig : ScriptableObject
    {
        public KeyCode openInventory;
        public KeyCode openUnitsList;
    }
}