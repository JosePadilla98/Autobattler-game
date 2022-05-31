using Autobattler.Units.Management;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Autobattler.UnitsScreenHandler
{
    public class Portrait : MonoBehaviour
    {
        [SerializeField]
        private Image image;
        [SerializeField]
        private TextMeshProUGUI nameText;

        public void OnUnitSlotSelected(MonoBehaviour monoBehaviour)
        {
            var slot = monoBehaviour as UnitsList_Slot;
            AttachUnitView(slot.getItemContained<UnitView>());
        }

        public void AttachUnitView(UnitView unitView)
        {
            image.sprite = unitView.unit.sprite;
            nameText.text = unitView.unit.name;
        }
    }
}