
using Assets.Code.Backend.RunLogic.GenericGrid;
using System;
using UnityEngine;

namespace Auttobattler.Backend.RunLogic.Management
{
    [Serializable]
    public class ManagementState
    {
        [SerializeField]
        internal LevelsSystem levelsSystem;
        internal PlayerData playerData;
        internal GridsController<Unit> gridsController;

        public void Init()
        {
            playerData = new PlayerData();
            levelsSystem.Init(this);
        }
    }
}
