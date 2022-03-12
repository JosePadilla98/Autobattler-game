using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Auttobattler.Data;

namespace Auttobattler
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField]
        private Level[] levels;
    }

    [System.Serializable]
    public class Level
    {
        public BuildedUnitBlueprint[] frontRow;
        public BuildedUnitBlueprint[] backRow;
    }
}

