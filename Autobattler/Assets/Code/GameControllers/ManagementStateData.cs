using System;
using Autobattler.Grid.Generic;
using Autobattler.ScriptableCollections;
using Autobattler.Units;

namespace Autobattler.GameControllers
{
    [Serializable]
    public class ManagementStateData
    {
        public GridsController<_Unit> managementBattlefield;
        public UnitsCollection enemies;
        public PlayerData playerData;
    }
}