using System;
using UnityEngine;

namespace Autobattler.LevelSystem
{
    [CreateAssetMenu(fileName = "LevelSystem", menuName = "ScriptableObjects/LevelSystem/LevelSystem")]
    public class LevelsSystem : ScriptableObject
    {
        public int currentLevel = 0;
        public LevelsData data;

        [SerializeField] 
        private InvocationsProcessor invocationsProcessor;

        public void Init()
        {
            LoadLevel(data.levels[currentLevel]);
        }

        private void LoadLevel(Level level)
        {
            invocationsProcessor.SummonEnemies(level.enemies);
        }
    }
}