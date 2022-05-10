
using System;
using UnityEngine;

namespace Auttobattler.Backend
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
