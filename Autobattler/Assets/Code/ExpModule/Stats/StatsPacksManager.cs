using System.Collections.Generic;
using Autobattler.Units;

namespace Autobattler.ExpModule.Stats
{
    public class StatsPacksManager
    {
        private List<StatsPackModel> unopenedPacks = new();
        private StatPackOpened currentPackOpened;
        public StatPackOpened CurrentPackOpened => currentPackOpened;
        public int UnopenedPacksLeft => unopenedPacks.Count;

        private StatsContainer statsContainer;

        public StatsPacksManager(StatsContainer statsContainer)
        {
            this.statsContainer = statsContainer;
        }

        public List<StatModElement> GetCurrentElements()
        {
            return currentPackOpened.currentRound.elements;
        }

        public void Add(StatsPackModel pack)
        {
            if (currentPackOpened == null)
            {
                OpenPack(pack);
                return;
            }

            unopenedPacks.Add(pack);
        }

        private void OpenPack(StatsPackModel pack)
        {
            currentPackOpened = new StatPackOpened(statsContainer, pack, TryOpenNextPack);
        }

        private void TryOpenNextPack()
        {
            currentPackOpened = null;

            if (unopenedPacks.Count == 0)
                return;

            OpenPack(unopenedPacks[0]);
            unopenedPacks.RemoveAt(0);
        }
    }
}