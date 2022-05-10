using System;
using UnityEngine;

namespace Auttobattler.Backend
{
    public enum RunState
    {
        COMBAT,
        MANAGEMENT,
        NONE
    }

    [Serializable]
    public class Run
    {
        private RunState state = RunState.NONE;
        private CombatState combatState;
        [SerializeField]
        private ManagementState managementState;

        public RunState State { get => state; }

        public Action OnCombatInit;
        public Action OnManagementInit;

        internal void Init()
        {
            ChangeState(RunState.MANAGEMENT);
        }

        public void StartCombat()
        {
            ChangeState(RunState.COMBAT);
        }

        public void ChangeState(RunState state)
        {
            switch (state)
            {
                case RunState.MANAGEMENT:
                    state = RunState.MANAGEMENT;
                    OnManagementInit();
                    break;

                case RunState.COMBAT:
                    state = RunState.COMBAT;
                    OnCombatInit();
                    break;
            }
        }

        public void Refresh()
        {

        }
    }
}
