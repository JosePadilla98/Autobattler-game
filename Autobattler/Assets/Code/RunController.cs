using Autobattler.LevelSystem;
using UnityEngine;

namespace Autobattler
{
    [CreateAssetMenu(fileName = "RunController", menuName = "ScriptableObjects/RunController")]
    public class RunController : ScriptableObject
    {
        public LevelsSystem levelsSystem;

        public void Init()
        {
            levelsSystem.Init();
        }
    }
}
