using Autobattler.DragAndDrop;
using Autobattler.MutationsSystem;
using Autobattler.MutationsSystem.Mutations;
using UnityEngine;

namespace Autobattler.UnitsScreenHandler
{
    public class Mutation_Slot : Mutation_BaseSlot
    {

        protected override bool CanThisObjectBeDroppedHere(DraggableComponent draggable)
        {
            if (draggable.item is not MutationView)
                return false;

            var mutation = ((MutationView)draggable.item).mutation;
            return mutation.Model.canBeDisabledByPlayer;
        }
    }
}