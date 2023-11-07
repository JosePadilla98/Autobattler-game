using AutobattlerOld.ExpModule.Stats;
using AutobattlerOld.Units.Management;

namespace AutobattlerOld.ExpModule
{
    public class ExperiencieModule
    {
        private Unit parent;

        private StatsPacksManager statsManager;
        public StatsPacksManager StatsManager => statsManager;

        #region MODEL DATA

        private UnitsLevellingModel lvBonifications;
        private LevelBonifications[] levelBonuses => lvBonifications.data;

        #endregion


        public ExperiencieModule(Unit parent, UnitsLevellingModel lvBonifications)
        {
            this.parent = parent;
            this.lvBonifications = lvBonifications;

            statsManager = new StatsPacksManager(parent.statsContainer);
        }

        public void GetLevelBonifications(LevelBonifications level)
        {
            foreach (var statPack in level.statsPacks)
            {
                statsManager.Add(statPack);
            }
        }
    }
}
