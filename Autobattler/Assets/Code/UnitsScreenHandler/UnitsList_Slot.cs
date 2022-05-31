using Autobattler.Configs;
using Autobattler.DragAndDrop;
using Autobattler.Units.Management;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Autobattler.UnitsScreenHandler
{
    public class UnitsList_Slot : DropArea, IPointerClickHandler
    {
        [SerializeField]
        private Image image;
        [SerializeField]
        private ColorModel selectedColor;
        [SerializeField]
        private ColorModel unselectedColor;

        private bool selected;

        public void InyectDependencies(Canvas canvas)
        {
            this.canvas = canvas;
        }

        protected override bool CanThisObjectBeDroppedHere(DraggableComponent draggable)
        {
            return draggable.item is UnitView;
        }

        public void Select()
        {
            image.color = selectedColor.color;
            selected = true;
        }

        public void Unselect()
        {
            image.color = unselectedColor.color;
            selected = false;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (!selected)
            {
                Select();
            }
            else
            {
                Unselect();
            }
        }
    }
}