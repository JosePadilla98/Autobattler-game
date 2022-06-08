using Autobattler.DragAndDrop;
using Autobattler.Units.Management;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Autobattler.Screens
{
    public class EditUnitScreen : MonoBehaviour
    {
        private Unit attachedUnit;
        public Image image;
        public TMP_InputField nameText;

        private EditScreenInfo info;

        public void Enable(object obj)
        {
            info = (EditScreenInfo)obj;
            AttachUnit(info.unitToEdit);
        }

        private void AttachUnit(Unit unit)
        {
            gameObject.SetActive(true);
            attachedUnit = unit;
            image.sprite = unit.sprite;
            nameText.text = unit.name;
        }

        public void Save()
        {
            attachedUnit.name = nameText.text;
            ObjectBeingDragged.CancelDragging();
            gameObject.SetActive(false);
            info.onClose.Invoke();
        }
    }
}