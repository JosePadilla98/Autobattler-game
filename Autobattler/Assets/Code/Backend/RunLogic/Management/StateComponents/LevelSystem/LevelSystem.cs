using UnityEngine;
using System;
using Assets.Code.Backend.RunLogic.Management.Controllers.LevelSystem;

namespace Auttobattler.Backend.RunLogic.Management
{
    [Serializable]
    public class LevelsSystem 
    {
        [SerializeField]
        private LevelsData data;
        [SerializeField]
        private int currentLevel = 1;

        internal ManagementState parent;
        private LevelSummnoner summoner;

        public void Init(ManagementState parent)
        {
            this.parent = parent;
            summoner = new LevelSummnoner(this);
            LoadLevel(data.levels[currentLevel]);
        }

        private void LoadLevel(Level level)
        {
            summoner.SummonEnemies(level.enemies);
        }
    }

   

}

