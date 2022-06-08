using System;
using Autobattler.InfoPanel;
using UnityEngine;

namespace Autobattler.InventorySystem.Items
{
    [CreateAssetMenu(fileName = "MonsterCapsuleModel", menuName = "ScriptableObjects/Items/MonsterCapsuleModel")]
    public class MonsterCapsuleModel : ItemScriptable
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