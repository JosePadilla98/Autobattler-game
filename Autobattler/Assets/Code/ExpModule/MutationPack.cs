using UnityEngine;

namespace Autobattler.Units.Management
{
    [SerializeField]
    public struct MutationPack
    {
        public int choicesNum;
        public int mutationsNum;

        public MutationPack(int choicesNum, int mutationsNum)
        {
            this.choicesNum = choicesNum;
            this.mutationsNum = mutationsNum;
        }
    }
}