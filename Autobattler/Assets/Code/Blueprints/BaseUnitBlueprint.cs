﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auttobattler.Scriptables
{
    [CreateAssetMenu(fileName = "BaseUnit", menuName = "ScriptableObjects/Unit/BaseUnitBlueprint", order = 1)]
    public class BaseUnitBlueprint : ScriptableObject
    {
        public string unitName;
        public Sprite sprite;
        public Stats stats;
    }
}