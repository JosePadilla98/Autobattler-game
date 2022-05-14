using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Autobattler.Units
{
    public class UnitView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public Image image;
        public Unit unit;

        public void OnPointerEnter(PointerEventData eventData)
        {
            //UnitInfoPanel.Instance?.AttachUnit(comb);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            //UnitInfoPanel.Instance?.Unattach();
        }
    }
}