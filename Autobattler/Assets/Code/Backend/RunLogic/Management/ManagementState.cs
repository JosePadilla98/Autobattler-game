
using System;
using UnityEngine;

namespace Auttobattler.Backend.RunLogic.Management
{
    [Serializable]
    public class ManagementState
    {
        internal PlayerData playerData;
        internal Summnoner summnoner;
        [SerializeField]
        internal GridsWrapper grids;
        [SerializeField]
        internal LevelsSystem levelsSystem;

        public void Init()
        {
            playerData = new PlayerData();
            summnoner = new Summnoner(this);
            levelsSystem.Init(this);
        }
    }
}
