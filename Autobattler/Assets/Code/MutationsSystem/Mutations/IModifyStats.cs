using Autobattler.Units;
using Autobattler.Units.Management;

namespace Autobattler.MutationsSystem.Mutations
{
    public interface IModifyStats
    {
        public abstract void ModifyStats(StatsContainer statsContainer);

        public abstract void UnmodifyStats(StatsContainer statsContainer);
    }
}