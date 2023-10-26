using AutobattlerOld.DragAndDrop;
using AutobattlerOld.Units.Management;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AutobattlerOld.Screens
{
    public class EditUnitScreen : MonoBehaviour
    {
        private Unit attachedUnit;
        public Image image;
        public TMP_InputField nameText;

        private ScreenInfo_Unit info;
        public UnityEvent<Unit> RefreshItems;

        public void Enable(object obj)
        {
            info = (ScreenInfo_Unit)obj;
            AttachUnit(info.unit);
        }

        private void AttachUnit(Unit unit)
        {
            gameObject.SetActive(true);
            attachedUnit = unit;
            image.sprite = unit.sprite;
            nameText.text = unit.name;
            RefreshItems?.Invoke(unit);
        }

        public void Save()
        {
            attachedUnit.name = nameText.text;
            attachedUnit.sprite = image.sprite;


            ObjectBeingDragged.CancelDragging();
            gameObject.SetActive(false);
            info.onClose.Invoke();
        }

        public void ChangeUnitSprite(Sprite sprite)
        {
            image.sprite = sprite;
        }
    }
}