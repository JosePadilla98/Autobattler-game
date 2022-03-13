using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auttobattler.Combat
{
    [RequireComponent(typeof(Battlefield))]
    public class CombatController : MonoBehaviour
    {
        public List<Unit> leftTeam = new List<Unit>();
        public List<Unit> rightTeam = new List<Unit>();

        public bool combatStarted = false;

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

        private void Awake()
        {
            Instance = this;
        }

        private void FixedUpdate()
        {
            if (!combatStarted) return;

            foreach (var item in leftTeam)
            {
                item.combatModule.Refresh();
            }

            foreach (var item in rightTeam)
            {
                item.combatModule.Refresh();
            }
        }
    }
}