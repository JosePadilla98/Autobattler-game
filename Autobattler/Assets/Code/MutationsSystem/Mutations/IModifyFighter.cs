using Autobattler.Units.Combat;

namespace Autobattler.MutationsSystem.Mutations
{
    public interface IModifyFighter
    {
        /// <summary>
        /// </summary>
        /// <param name="order">
        ///     The mutation instance index in the fighter's collection. Some mutations need to know this (see the
        ///     chargerSystem)
        /// </param>
        /// <param name="key">The mutation instance ID of a fighter</param>
        /// <param name="fighter"></param>
        public abstract void AttachToFighter(int order, int key, Fighter fighter);

    
        public abstract void UnattachToFighter(int key, Fighter fighter);
    }
}