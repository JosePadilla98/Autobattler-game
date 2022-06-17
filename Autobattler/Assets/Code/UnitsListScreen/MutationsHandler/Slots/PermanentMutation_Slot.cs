using Autobattler.DragAndDrop;
using Autobattler.MutationsSystem;

namespace Autobattler.UnitsListScreen.MutationsHandler.Slots
{
    public class PermanentMutation_Slot : Mutation_BaseSlot
    {
        protected override bool CanThisObjectBeDroppedHere(DraggableComponent draggable)
        {
            if (draggable.item is not MutationView)
                return false;

            var mutation = ((MutationView)draggable.item).mutation;
            return !mutation.Model.canBeDisabledByPlayer;
        }
    }
}