using System;
using Autobattler.Events;
using Autobattler.InfoPanel;
using Autobattler.Screens;
using Autobattler.Units;
using UnityEngine;

namespace Autobattler.InventorySystem.Items
{
    [CreateAssetMenu(fileName = "MonsterCapsuleModel", menuName = "ScriptableObjects/Items/MonsterCapsuleModel")]
    public class MonsterCapsuleModel : ItemScriptable
    {
        [SerializeField]
        [Space(20)]
        private UnitsCreator unitsCreator;

        [SerializeField] 
        [Space(20)] 
        private GameEvent_Generic openEditUnitScreen;

        public override TextPanelData GetDescription()
        {
            return info;
        }

        public override void OnClick(ItemView itemView)
        {
            var unit = unitsCreator.CreateNewPlayerUnit();
            itemView.DestroyItem();
            openEditUnitScreen.Raise(new EditUnitInfo(unit, () => Debug.Log("hello")));
        }
    }
}