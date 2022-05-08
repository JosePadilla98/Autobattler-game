using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Auttobattler.Scriptables;
using Auttobattler.Combat;
using System;

namespace Auttobattler.LevelsSystem
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

