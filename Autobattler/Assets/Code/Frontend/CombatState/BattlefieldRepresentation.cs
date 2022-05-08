using UnityEngine;
using System;
using Auttobattler.Backend.Run.CombatState;
using Auttobattler.Backend.Run;

namespace Auttobattler.Frontend.CombatState
{
    public class BattlefieldRepresentation : MonoBehaviour
    {
        public GridRepresentation leftSide;
        public GridRepresentation rightSide;

        private Battlefield Battlefield { get => Battlefield.Instance; }

        #region SINGLETON
        private static BattlefieldRepresentation instance;
        public static BattlefieldRepresentation Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion 

        private void Awake()
        {
            if (instance != null)
                throw new Exception("You must not instantite this another time");
            instance = this;

            //Attach representations
            leftSide.AttachToLogic(Battlefield.leftGrid);
            rightSide.AttachToLogic(Battlefield.rightGrid);

            Battlefield.OnUnitSummoned += BuildUnitRepresentation;
        }

        private void BuildUnitRepresentation(Fighter combatInstance, CombatSlot slot)
        {
           
        }
    }

    [Serializable]
    public class GridRepresentation
    {
        public CombatSlotRepresentation[] front;
        public CombatSlotRepresentation[] back;
        public Side side;

        public void AttachToLogic(CombatGrid grid)
        {
            for (int i = 0; i < 3; i++)
            {
                front[i].AttachToLogic(grid.front[i]);
                back[i].AttachToLogic(grid.back[i]);
            }
        }
    }
}
