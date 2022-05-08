using UnityEngine;
using System;

namespace Auttobattler.Backend.Run.ManagementState
{
    public class LevelsSystem : MonoBehaviour
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
            //SummonEnemyUnits(level.invocationsData);
        }
    }

}

