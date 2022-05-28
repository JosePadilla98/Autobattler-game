using Autobattler.ScriptableCollections;
using UnityEngine;

namespace Autobattler.GameControllers.Combat
{
    [CreateAssetMenu(fileName = "TeamsController", menuName = "ScriptableObjects/TeamsController")]
    public class FighterTeamsController : ScriptableObject
    {
        public FightersCollection enemies;
        public FightersCollection playerFighters;
    }
}