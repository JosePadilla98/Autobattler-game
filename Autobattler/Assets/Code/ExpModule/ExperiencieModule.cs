namespace Autobattler.Units.Management
{
    public class ExperiencieModule
    {
        private Unit parent;

        private int Level
        {
            get => parent.statsContainer.level;
            set => parent.statsContainer.level = value;
        }

        public int statsValueToModify;

        private LevelsBonificationsModel lvBonificationsModel;
        private LevelBonifications[] levelBonuses => lvBonificationsModel.LevelsBonifications;

        public ExperiencieModule(Unit parent, LevelsBonificationsModel lvBonificationsModel)
        {
            this.parent = parent;
            this.lvBonificationsModel = lvBonificationsModel;
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
            statsValueToModify += level.statsValueToModify;
        }
    }
}