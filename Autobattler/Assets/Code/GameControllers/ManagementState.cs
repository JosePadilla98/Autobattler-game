using System;
using Autobattler.Grid.Generic;
using Autobattler.Grid.Logic;
using Autobattler.InventorySystem;
using Autobattler.LevelSystem;
using Autobattler.ScriptableCollections;
using Autobattler.Units;
using Autobattler.Units.Management;

namespace Autobattler.GameControllers
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
            levelsSystem.LoadNextLevel();
            itemsController.CreateInitialItems();
        }
    }
}