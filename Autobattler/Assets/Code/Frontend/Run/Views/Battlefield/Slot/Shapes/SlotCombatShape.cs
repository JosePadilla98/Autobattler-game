using Assets.Code.Frontend.Run.Views.Unit.Shapes;
using Auttobattler;
using Auttobattler.Backend.RunLogic.Combat;

namespace Assets.Code.Frontend.Run.Views.Battlefield.Slot
{
    class SlotCombatShape
    {
        private UnitCombatShape fighterRepresentation;

        //public void AttachUnitrepresentation(Fighter combatInstance)
        //{
        //    fighterRepresentation = Instantiate(GameAssets.Instance.fighterRepresentation, gameObject.transform);
        //    fighterRepresentation.AttachCombatInstance(combatInstance);

        //    if (combatSlot.Side == Side.RIGHT)
        //    {
        //        fighterRepresentation.image.transform.localScale = new Vector3(-1, 1, 1);
        //    }
        //}

        //public void AttachToLogic(CombatSlot combatSlot)
        //{
        //    this.combatSlot = combatSlot;
        //    combatSlot.OnUnitAttached += AttachUnitrepresentation;
        //}
    }
}
