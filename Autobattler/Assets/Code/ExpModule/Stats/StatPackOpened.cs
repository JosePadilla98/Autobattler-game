﻿using System;
using Autobattler.Units;

namespace Autobattler.ExpModule.Stats
{
    public class StatPackOpened
    {
        public StatsPackModel model;
        private StatsContainer statsContainer;
        private Action onConsumed;

        private int roundsToDo;
        private float valueLeftToModify;

        public StatsPackRound currentRound;

        public StatPackOpened(StatsContainer statsContainer, StatsPackModel model, Action onConsumed)
        {
            this.model = model;
            this.onConsumed = onConsumed;
            this.statsContainer = statsContainer;

            valueLeftToModify = model.totalValueToModify;
            roundsToDo = model.desirableNumOfRounds;

            NewRound();
        }

        private void NewRound()
        {
            var roundValue = valueLeftToModify / roundsToDo;
            bool applyValueVariation = roundsToDo > 1;
            currentRound = new StatsPackRound(OnRoundConsumed, statsContainer, model.roundData, roundValue, applyValueVariation);
        }

        private void OnRoundConsumed()
        {
            valueLeftToModify -= currentRound.RoundValue;
            roundsToDo--;

            if (valueLeftToModify == 0)
            {
                currentRound = null;
                Consume();
            }
            else
            {
                NewRound();
            }
        }

        private void Consume()
        {
            onConsumed.Invoke();
            onConsumed = null;
        }
    }
}