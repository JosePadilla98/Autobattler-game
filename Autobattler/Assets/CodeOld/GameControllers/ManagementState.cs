﻿using System;
using AutobattlerOld.Grid.Generic;
using AutobattlerOld.Grid.Logic;
using AutobattlerOld.InventorySystem;
using AutobattlerOld.LevelSystem;
using AutobattlerOld.RunData;
using AutobattlerOld.ScriptableCollections;
using AutobattlerOld.Units;
using AutobattlerOld.Units.Management;

namespace AutobattlerOld.GameControllers
{
    [Serializable]
    public class ManagementState
    {
        public ItemsController itemsController;
        public Battlefield_U managementBattlefield;
        public UnitsCollection enemies;
        public PlayerData playerData;
        public LevelsSystem levelsSystem;

        public void Init()
        {
            playerData.Init();
            levelsSystem.LoadNextLevel();
            itemsController.Init();
        }
    }
}