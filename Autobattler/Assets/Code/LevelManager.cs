using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Auttobattler.Scriptables;

namespace Auttobattler
{
    public class LevelManager : MonoBehaviour
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
            Battlefield.Instance.SummonEnemies(level);
        }
    }

    [System.Serializable]
    public class Level
    {
        public BuildedUnitBlueprint[] frontColumn;
        public BuildedUnitBlueprint[] backColumn;
    }
}

