using UnityEngine;
using System;

namespace Auttobattler.Backend.Run.ManagementState
{
    public class LevelUnitsLoader : MonoBehaviour
    {
        [SerializeField]
        private int levelCount;

        [SerializeField]
        private Level[] levels;

        private void Start()
        {
            LoadLevel(levels[levelCount]);
        }

        private void LoadLevel(Level level)
        {
            PreCombatSummoner.SummonEnemyUnits(level.invocationsData);
        }
    }

}

