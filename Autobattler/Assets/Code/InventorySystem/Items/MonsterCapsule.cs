using System;
using Autobattler.InfoPanel;
using UnityEngine;

namespace Autobattler.InventorySystem.Items
{
    [CreateAssetMenu(fileName = "MonsterCapsule", menuName = "ScriptableObjects/Items/MonsterCapsule")]
    public class MonsterCapsule : ItemScriptable
    {
        public override TextPanelData GetDescription()
        {
            return info;
        }

        public override void OnClick()
        {

        }
    }
}