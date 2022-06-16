using System;
using System.Runtime.InteropServices;
using Autobattler.Events;
using Autobattler.Screens;
using Autobattler.Units.Management;
using UnityEngine;
using UnityEngine.Events;

namespace Autobattler.UnitLevelBonusesScreen
{
    public class MutationsBonusScreen : MonoBehaviour
    {
        [SerializeField]
        private GameEvent_Generic goToStatsModsScreen;

        [SerializeField]
        [Space(20)]
        private UnityEvent<EditUnitInfo> refreshItems;

        private EditUnitInfo attachedData;

        public void Close()
        {
            attachedData.onClose();
            gameObject.SetActive(false);
        }

        public void Enable(object obj)
        {
            attachedData = (EditUnitInfo)obj;
            refreshItems?.Invoke(attachedData);
            gameObject.SetActive(true);
        }

        public void GoToStatsModsScreen()
        {
            gameObject.SetActive(false);
            goToStatsModsScreen.Raise(attachedData);
        }
    }
}