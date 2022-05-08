
using Assets.Code.Backend.RunLogic.CombatState.Controllers.Battlefield;
using Assets.Code.Frontend.Run.Views.Battlefield;

namespace Auttobattler.Backend.RunLogic.CombatState
{
    public class CombatState
    {
        private bool isActive;

        private TeamsController teamsController;
        private CombatSummoner combatSummoner;
        //private Battlefield battlefield;
        private BattlefieldView battlefieldRepresentation;
    }
}
