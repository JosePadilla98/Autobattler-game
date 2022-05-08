
using Assets.Code.Backend.Run.CombatState.Controllers.Battlefield;
using Auttobattler.Frontend.CombatScreen;

namespace Auttobattler.Backend.Run.CombatState
{
    public class CombatState
    {
        private bool isActive;

        private TeamsController teamsController;
        private CombatSummoner combatSummoner;
        private Battlefield battlefield;
        private BattlefieldRepresentation battlefieldRepresentation;
    }
}
