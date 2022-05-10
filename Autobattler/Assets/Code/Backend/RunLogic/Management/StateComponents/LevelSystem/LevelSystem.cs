using System;
using UnityEngine;

namespace Auttobattler.Backend
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

