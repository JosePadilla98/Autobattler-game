using AutobattlerOld.DragAndDrop;
using AutobattlerOld.MutationsSystem;
using AutobattlerOld.MutationsSystem.Mutations;
using UnityEngine;

namespace AutobattlerOld.UnitsListScreen.MutationsHandler.Slots
{
    public class Mutation_BaseSlot : DropArea
    {
        public Mutation MutationContained => (draggableObj.item as MutationView).mutation;
        public bool HasItem => draggableObj != null;

        protected Mutations_BasePanel panelParent;

        public void InyectDependencies(Canvas canvas, Mutations_BasePanel panel)
        {
            this.canvas = canvas;
            panelParent = panel;
        }

        protected override void MyLastItemHasBeenPlacedSomewhere(DropArea dropAreaWherePlaced, DraggableComponent draggable)
        {
            base.MyLastItemHasBeenPlacedSomewhere(dropAreaWherePlaced, draggable);

            var slot = dropAreaWherePlaced as Mutation_BaseSlot;
            if (slot.panelParent != this.panelParent)
                panelParent.UnattachMutation(((MutationView)draggable.item).mutation);
        }

        protected override void SwapPlaces(DraggableComponent itemToSwap)
        {
            base.SwapPlaces(itemToSwap);
            panelParent.SaveChanges();
        }

        public override void Drop(DraggableComponent draggable)
        {
            base.Drop(draggable);
            panelParent.CheckIfAttachMutation(((MutationView)draggable.item).mutation);
        }
    }
}