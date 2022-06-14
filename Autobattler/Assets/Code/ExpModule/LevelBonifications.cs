using System;

namespace Autobattler.Units.Management
{
    [Serializable]
    public struct LevelBonifications
    {
        public int statsValueToModify;
        public MutationPack[] mutationsPacks;
    }
}