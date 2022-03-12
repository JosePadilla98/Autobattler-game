using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auttobattler.Data
{
    [CreateAssetMenu(fileName = "Creature", menuName = "ScriptableObjects/BuildedUnitBlueprint", order = 2)]
    public class BuildedUnitBlueprint : ScriptableObject
    {
        public int level;
        public CreatureBlueprint baseBlueprint;
    }

    public class CreatureModifier
    {

    }
}