using Autobattler.DragAndDrop;
using Autobattler.MutationsSystem;
using Autobattler.MutationsSystem.Mutations;
using UnityEngine;

namespace Autobattler.UnitsScreenHandler
{
    public class Mutation_BaseSlot : DropArea
    {
        public Mutation MutationContained => (draggableObj.item as MutationView).mutation;
        public bool HasItem => draggableObj != null;

        public void InyectDependencies(Canvas canvas)
        {
            this.canvas = canvas;
        }
    }
}