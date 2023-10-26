using AutobattlerOld.Units;
using AutobattlerOld.Units.Management;

namespace AutobattlerOld.MutationsSystem.Mutations
{
    public interface IModifyStats
    {
        public abstract void ModifyStats(StatsContainer statsContainer);

        public abstract void UnmodifyStats(StatsContainer statsContainer);
    }
}