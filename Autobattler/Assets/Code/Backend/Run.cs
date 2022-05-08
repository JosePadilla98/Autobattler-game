using System;
using UnityEngine;

namespace Assets.Code.Backend
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
        [SerializeField]
        private RunState state;

        public void ChangeState(RunState state)
        {
            switch (state)
            {
                case RunState.COMBAT:
                    this.state = RunState.COMBAT;
                    break;

                case RunState.MANAGEMENT:
                    this.state = RunState.MANAGEMENT ;
                    break;
            }
        }
    }
}
