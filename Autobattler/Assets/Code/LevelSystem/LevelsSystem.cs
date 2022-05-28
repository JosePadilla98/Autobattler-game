using System;
using Autobattler.Grid;
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

        [SerializeField]
        private InvocationsData playerUnits;

        public void Init()
        {
            LoadLevel(data.levels[currentLevel]);
        }

        private void LoadLevel(Level level)
        {
            //You will only summon units in the player side to test
            invocationsProcessor.SummonUnits(playerUnits, Side.LEFT);
            invocationsProcessor.SummonUnits(level.enemies, Side.RIGHT);
        }
    }
}