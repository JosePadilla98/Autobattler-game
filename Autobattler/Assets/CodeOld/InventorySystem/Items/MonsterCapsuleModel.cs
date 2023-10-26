using System;
using AutobattlerOld.Events;
using AutobattlerOld.InfoPanel;
using AutobattlerOld.Screens;
using AutobattlerOld.Units;
using AutobattlerOld.Units.Management;
using UnityEngine;

namespace AutobattlerOld.InventorySystem.Items
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

            void NextStep() => openMutationsHandler.Raise(new ScreenInfo_Unit(unit, openInventory.Raise));
            openEditUnitScreen.Raise(new ScreenInfo_Unit(unit, NextStep));
        }
    }
}