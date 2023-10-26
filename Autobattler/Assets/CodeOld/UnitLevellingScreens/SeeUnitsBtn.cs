using AutobattlerOld.Events;
using AutobattlerOld.Screens;
using UnityEngine;

namespace AutobattlerOld.UnitLevellingScreens
{
    public class SeeUnitsBtn : MonoBehaviour
    {
        [SerializeField]
        private GameObject screenParent;
        [SerializeField]
        private UnitsScreen unitsScreen;
        [SerializeField]
        private GameEvent_Generic comeBackEvent;

        private ScreenInfo_Unit attachedData;

        public void AttachData(ScreenInfo_Unit data)
        {
            attachedData = data;
        }

        public void OnClick()
        {
            void ComeBack() => comeBackEvent.Raise(attachedData);
            unitsScreen.Enable(new ScreenInfo_Unit(attachedData.unit, ComeBack));
            screenParent.SetActive(false);
        }
    }
}