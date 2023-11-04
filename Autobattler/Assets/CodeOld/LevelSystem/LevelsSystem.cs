using System;
using AutobattlerOld.Grid;
using UnityEngine;

namespace AutobattlerOld.LevelSystem
{
    [CreateAssetMenu(
        fileName = "LevelSystem",
        menuName = "ScriptableObjects/LevelSystem/LevelSystem"
    )]
    public class LevelsSystem : ScriptableObject
    {
        public int currentLevel = 0;
        public LevelsData data;

        [Space(20)]
        [SerializeField]
        private InvocationsProcessor invocationsProcessor;

        [Space(20)]
        [SerializeField]
        private InvocationsData playerTestingUnits;

        public void LoadNextLevel()
        {
            LoadLevel(data.levels[currentLevel]);
        }

        private void LoadLevel(Level level)
        {
            //It will only summon units in the player side to test
            invocationsProcessor.SummonUnits(playerTestingUnits, Side.LEFT);
            invocationsProcessor.SummonUnits(level.enemies, Side.RIGHT);
        }
    }
}
