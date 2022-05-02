﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auttobattler.Combat
{
    [RequireComponent(typeof(Battlefield))]
    public class CombatController : MonoBehaviour
    {
        public List<UnitRepresentation> leftTeam = new List<UnitRepresentation>();
        public List<UnitRepresentation> rightTeam = new List<UnitRepresentation>();

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

        public void startCombat()
        {
            PrepareTeam(leftTeam);
            PrepareTeam(rightTeam);

            combatStarted = true;
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

        private void Awake()
        {
            Instance = this;
        }

        private void FixedUpdate()
        {
            if (!combatStarted) return;

            foreach (var item in leftTeam)
            {
                item.CombatInstance.Refresh();
            }

            foreach (var item in rightTeam)
            {
                item.CombatInstance.Refresh();
            }
        }
    }
}