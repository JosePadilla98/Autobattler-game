﻿using Autobattler.Events;
using Autobattler.Screens;
using Autobattler.Units.Management;
using UnityEngine;
using UnityEngine.Events;

namespace Autobattler.UnitLevelBonusesScreen
{
    public class StatsModsScreen : MonoBehaviour
    {
        [SerializeField]
        private GameEvent_Generic goToMutationsBonusScreen;

        [SerializeField]
        [Space(20)]
        private UnityEvent<EditUnitInfo> refreshItems;
        [SerializeField]
        [Space(20)]
        private UnityEvent<Unit> refreshItems2;


        private EditUnitInfo attachedData;

        public void Enable(object obj)
        {
            attachedData = (EditUnitInfo)obj;
            refreshItems?.Invoke(attachedData);
            refreshItems2?.Invoke(attachedData.unit);
            gameObject.SetActive(true);
        }

        public void GoToStatsModsHandler()
        {
            gameObject.SetActive(false);
            goToMutationsBonusScreen.Raise(attachedData);
        }
    }
}