﻿using Autobattler.Events;
using Autobattler.Screens;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Autobattler.UnitLevellingScreens
{
    public class LevelBonusPortrait : MonoBehaviour
    {
        [SerializeField]
        private Image image;
        [SerializeField]
        private TextMeshProUGUI nameText;
        [SerializeField]
        private GameObject screenParent;

        [SerializeField]
        private GameEvent_Generic comeBackEvent;
        [SerializeField]
        private GameEvent_Generic goToEditScreen;

        private EditUnitInfo attachedData;

        public void AttachData(EditUnitInfo data)
        {
            var unit = data.unit;
            image.sprite = unit.sprite;
            nameText.text = unit.name;
            attachedData = data;
        }

        public void OnClick()
        {
            void ComeBack() => comeBackEvent.Raise(attachedData);
            goToEditScreen.Raise(new EditUnitInfo(attachedData.unit, ComeBack));

            screenParent.SetActive(false);
        }
    }
}