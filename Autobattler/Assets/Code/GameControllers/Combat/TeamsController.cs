using Autobattler.ScriptableCollections;
using UnityEngine;

namespace Autobattler.States
{
    [CreateAssetMenu(fileName = "TeamsController", menuName = "ScriptableObjects/TeamsController")]
    public class TeamsController : ScriptableObject
    {
        public FightersCollection enemies;
        public FightersCollection playerFighters;
    }
}