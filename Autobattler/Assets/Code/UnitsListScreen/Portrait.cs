using Autobattler.Screens;
using Autobattler.Units.Management;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Autobattler.UnitsListScreen
{
    public class Portrait : MonoBehaviour
    {
        [SerializeField]
        private Image image;
        [SerializeField]
        private TextMeshProUGUI nameText;
        [SerializeField]
        private UnitsScreen unitsScreen;

        public void AttachUnit(Unit unit)
        {
            image.sprite = unit.sprite;
            nameText.text = unit.name;
        }

        public void OnClick()
        {
            unitsScreen?.GoToEditScreen();
        }
    }
}