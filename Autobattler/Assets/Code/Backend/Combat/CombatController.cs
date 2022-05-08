using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auttobattler.Combat
{
    public enum Team { PLAYER, ENEMY }

    [RequireComponent(typeof(Battlefield))]
    public class CombatController
    {
        public List<Fighter> playerTeam = new List<Fighter>();
        public List<Fighter> enemyTeam = new List<Fighter>();

        private bool combatStarted = false;

        #region SINGLETON

        private static CombatController instance;
        public static CombatController Instance
        {
            get
            {
                if (instance == null)
                    instance = new CombatController();

                return instance;
            }
        }

        #endregion 

        public void StartCombat()
        {
            combatStarted = true;
        }

        public void Refresh()
        {
            if (!combatStarted) return;

            foreach (var combatInstance in playerTeam)
            {
                combatInstance.Refresh();
            }

            foreach (var combatInstance in enemyTeam)
            {
                combatInstance.Refresh();
            }
        }

        public Team GetFighterTeam(Fighter unitCombatInstance)
        {
            foreach (var unit in playerTeam)
            {
                if (unitCombatInstance == unit)
                    return Team.PLAYER;
            }

            foreach (var unit in enemyTeam)
            {
                if (unitCombatInstance == unit)
                    return Team.ENEMY;
            }

            throw new Exception("Something is wrong");
        }

    }
}