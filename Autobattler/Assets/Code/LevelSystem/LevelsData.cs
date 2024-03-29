﻿using UnityEngine;

namespace Autobattler.LevelSystem
{
    [CreateAssetMenu(fileName = "LevelsData", menuName = "ScriptableObjects/LevelSystem/LevelsData")]
    public class LevelsData : ScriptableObject
    {
        public Level[] levels;
    }
}