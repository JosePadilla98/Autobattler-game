using System;
using Autobattler.Grid.Generic;
using Autobattler.ScriptableCollections;
using Autobattler.Units;
using Autobattler.Units.Management;

namespace Autobattler.GameControllers
{
    [Serializable]
    public class ManagementStateData
    {
        public GridsController<Unit> managementBattlefield;
        public UnitsCollection enemies;
        public PlayerData playerData;
    }
}