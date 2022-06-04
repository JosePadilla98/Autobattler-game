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

        public void AttachUnit(Unit unit)
        {
            image.sprite = unit.sprite;
            nameText.text = unit.name;
        }
    }
}