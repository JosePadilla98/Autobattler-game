using System;
using Autobattler.InfoPanel;
using Autobattler.Units;
using UnityEngine;

namespace Autobattler.InventorySystem.Items
{
    [CreateAssetMenu(fileName = "MonsterCapsuleModel", menuName = "ScriptableObjects/Items/MonsterCapsuleModel")]
    public class MonsterCapsuleModel : ItemScriptable
    {
        [SerializeField]
        private UnitsCreator unitsCreator;

        public override TextPanelData GetDescription()
        {
            return info;
        }

        public override void OnClick(ItemView itemView)
        {
            unitsCreator.CreateNewPlayerUnit();
            itemView.DestroyItem();
        }
    }
}