using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auttobattler.Combat
{
    public enum Team { PLAYER, ENEMY }

    [RequireComponent(typeof(Battlefield))]
    public class CombatController : MonoBehaviour
    {
        public List<UnitRepresentation> playerTeam = new List<UnitRepresentation>();

        public List<UnitRepresentation> enemyTeam = new List<UnitRepresentation>();

        private bool combatStarted = false;

        #region SINGLETON

        private static CombatController instance;
        public static CombatController Instance
        {
            get => instance;
            set
            {
                if (instance != null)
                    throw new System.Exception("Must be only one");

                instance = value;
            }
        }

        #endregion 

        public void StartCombat()
        {
            PrepareTeam(playerTeam);
            PrepareTeam(enemyTeam);

            combatStarted = true;
        }

        private void Awake()
        {
            Instance = this;
        }

        private void FixedUpdate()
        {
            if (!combatStarted) return;

            foreach (var item in playerTeam)
            {
                item.CombatInstance.Refresh();
            }

            foreach (var item in enemyTeam)
            {
                item.CombatInstance.Refresh();
            }
        }

        private void PrepareTeam(List<UnitRepresentation> team)
        {
            foreach (UnitRepresentation unit in team)
            {
                #if UNITY_EDITOR || DEVELOPMENT_BUILD
                if (unit == null)
                    Debug.Log("Look at the monobehaviour, you left there a null!");
                #endif

                unit.PreparativesToBattle();
            }
        }

        internal Team GetFighterTeam(UnitCombatInstance unitCombatInstance)
        {
            throw new NotImplementedException();
        }

    }
}