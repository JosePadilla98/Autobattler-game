using System;
using UnityEngine;

namespace Autobattler.LevelSystem
{
    [Serializable]
    public class LevelsSystem
    {
        [SerializeField] private int currentLevel = 1;

        [SerializeField] private LevelsData data;

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