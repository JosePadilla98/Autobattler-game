using AutobattlerOld.Events;
using AutobattlerOld.Screens;
using AutobattlerOld.Units.Management;
using UnityEngine;
using UnityEngine.Events;

namespace AutobattlerOld.UnitLevellingScreens
{
    public class StatsModsScreen : MonoBehaviour
    {
        [SerializeField]
        private GameEvent_Generic goToMutationsBonusScreen;

        [SerializeField]
        [Space(20)]
        private UnityEvent<ScreenInfo_Unit> refreshItems;
        [SerializeField]
        [Space(20)]
        private UnityEvent<Unit> refreshItems2;

        private ScreenInfo_Unit attachedData;

        public void Enable(object obj)
        {
            attachedData = (ScreenInfo_Unit)obj;
            Refresh();
            gameObject.SetActive(true);
        }

        public void Refresh()
        {
            refreshItems?.Invoke(attachedData);
            refreshItems2?.Invoke(attachedData.unit);
        }

        public void GoToStatsModsHandler()
        {
            gameObject.SetActive(false);
            goToMutationsBonusScreen.Raise(attachedData);
        }
    }
}