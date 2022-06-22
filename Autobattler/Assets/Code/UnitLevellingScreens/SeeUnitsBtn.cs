using Autobattler.Events;
using Autobattler.Screens;
using UnityEngine;

namespace Autobattler.UnitLevellingScreens
{
    public class SeeUnitsBtn : MonoBehaviour
    {
        [SerializeField]
        private GameObject screenParent;
        [SerializeField]
        private UnitsScreen unitsScreen;
        [SerializeField]
        private GameEvent_Generic comeBackEvent;

        private EditUnitInfo attachedData;

        public void AttachData(EditUnitInfo data)
        {
            attachedData = data;
        }

        public void OnClick()
        {
            void ComeBack() => comeBackEvent.Raise(attachedData);
            unitsScreen.Enable(ComeBack);
            unitsScreen.AttachUnit(attachedData.unit);

            screenParent.SetActive(false);
        }
    }
}