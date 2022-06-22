﻿using Autobattler.Events;
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

        private ScreenInfo_Unit attachedData;

        public void AttachData(ScreenInfo_Unit data)
        {
            attachedData = data;
        }

        public void OnClick()
        {
            void ComeBack() => comeBackEvent.Raise(attachedData);
            unitsScreen.Enable(attachedData);
            screenParent.SetActive(false);
        }
    }
}