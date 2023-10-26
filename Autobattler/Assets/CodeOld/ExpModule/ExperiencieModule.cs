using AutobattlerOld.ExpModule.Stats;
using AutobattlerOld.Units.Management;

namespace AutobattlerOld.ExpModule
{
    public class ExperiencieModule
    {
        private Unit parent;
        private int Level
        {
            get => parent.statsContainer.level;
            set => parent.statsContainer.level = value;
        }
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
            SetInitialLevelBonuses();
        }

        public void SetInitialLevelBonuses()
        {
            for (int i = 0; i < Level; i++)
            {
                GetLevelBonifications(levelBonuses[i]);
            }
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