using UnityEngine;
using System;
using Assets.Code.Backend.RunLogic.Management.Controllers.LevelSystem;

namespace Auttobattler.Backend.RunLogic.Management
{
    public class LevelsSystem 
    {
        [SerializeField]
        private LevelsData data;
        [SerializeField]
        private int currentLevel = 1;

        private ManagementState parent;
        private Summnoner Summnoner { get => parent.summnoner; }

        public void Init(ManagementState parent)
        {
            this.parent = parent;
            LoadLevel(data.levels[currentLevel]);
        }

        private void LoadLevel(Level level)
        {
            Summnoner.SummonEnemies(level.enemies);
        }
    }

   

}

