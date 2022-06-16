using System;
using Autobattler.Events;
using Autobattler.InfoPanel;
using Autobattler.Screens;
using Autobattler.Units;
using Autobattler.Units.Management;
using UnityEngine;

namespace Autobattler.InventorySystem.Items
{
    [CreateAssetMenu(fileName = "MonsterCapsuleModel", menuName = "ScriptableObjects/Items/MonsterCapsuleModel")]
    public class MonsterCapsuleModel : ItemScriptable
    {
        [SerializeField]
        [Space(20)]
        private UnitsCreator unitsCreator;

        [Header("Events")]
        [SerializeField] 
        [Space(20)] 
        private GameEvent_Generic openEditUnitScreen;
        [SerializeField]
        private GameEvent_Generic openMutationsHandler;
        [SerializeField]
        public GameEvent openInventory;

        public override TextPanelData GetDescription()
        {
            return info;
        }

        public override void OnClick(ItemView itemView)
        {
            var unit = unitsCreator.CreateNewPlayerUnit();
            itemView.DestroyItem();

            void NextStep() => openMutationsHandler.Raise(new EditUnitInfo(unit, openInventory.Raise));
            openEditUnitScreen.Raise(new EditUnitInfo(unit, NextStep));
        }
    }
}