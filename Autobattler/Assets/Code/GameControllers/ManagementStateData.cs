using System;
using Autobattler.Grid.Generic;
using Autobattler.Player;
using Autobattler.ScriptableCollections;
using Autobattler.Units;
using UnityEngine;

namespace Autobattler
{
    [Serializable]
    public class ManagementStateData
    {
        public GridsController<Unit> managementBattlefield;
        public UnitsCollection enemies;
        public PlayerData playerData;
    }
}