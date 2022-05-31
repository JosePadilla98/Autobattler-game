using Autobattler.DragAndDrop;
using Autobattler.MutationsSystem;
using Autobattler.MutationsSystem.Mutations;
using UnityEngine;

namespace Autobattler.UnitsScreenHandler
{
    public class PermanentsMutations_Slot : DropArea
    {
        public Mutation MutationContained => (draggableObj.item as MutationView).mutation;

        public void InyectDependencies(Canvas canvas)
        {
            this.canvas = canvas;
        }

        protected override bool CanThisObjectBeDroppedHere(DraggableComponent draggable)
        {
            if (draggable.item is not MutationView)
                return false;

            var mutation = ((MutationView)draggable.item).mutation;
            return !mutation.Model.canBeDisabledByPlayer;
        }
    }
}