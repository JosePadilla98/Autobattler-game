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

        [Space(20)]
        [SerializeField] 
        private InvocationsProcessor invocationsProcessor;

        [Space(20)]
        [SerializeField]
        private InvocationsData playerTestingUnits;

        public void Init()
        {
            LoadLevel(data.levels[currentLevel]);
        }

        private void LoadLevel(Level level)
        {
            //You will only summon units in the player side to test
            invocationsProcessor.SummonUnits(playerTestingUnits, Side.LEFT);
            invocationsProcessor.SummonUnits(level.enemies, Side.RIGHT);
        }
    }
}