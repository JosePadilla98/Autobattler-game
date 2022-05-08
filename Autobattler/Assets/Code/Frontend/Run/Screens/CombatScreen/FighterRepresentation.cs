using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Auttobattler.Backend.Run.CombatState;
using Auttobattler.Backend.Run.ManagementState;
using Assets.Code.Frontend.UnitView.Unit.Components.InfoBars;
using Assets.Code.Frontend.UnitView.Unit.Components;

namespace Auttobattler.Frontend.CombatScreen
{
    /// <summary>
    /// Represents a enemy unit ready to fight; in the pre-combat phase.
    /// Also represents a unit (enemy or player), fighting.
    /// </summary>
    public class FighterRepresentation : MonoBehaviour
    {
        public UnitInfoBars infoBars;
        public Image image;
        public Transform numberPopupsLocation;

        private AnimationsController animationsController;
        private Fighter combatInstance;

        public Fighter CombatInstance { get => combatInstance; }

        protected virtual void Awake()
        {
            animationsController = GetComponent<AnimationsController>();
        }

        public void AttachCombatInstance(Fighter combatInstance)
        {
            this.combatInstance = combatInstance;
            infoBars.AttachUnit(CombatInstance);
        }
    }

   

}
