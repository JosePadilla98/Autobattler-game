using AutobattlerOld.Events;
using AutobattlerOld.Screens;
using UnityEngine;
using UnityEngine.Events;

namespace AutobattlerOld.UnitLevellingScreens
{
    public class MutationsBonusesScreen : MonoBehaviour
    {
        [SerializeField]
        private GameEvent_Generic goToStatsModsScreen;

        [SerializeField]
        [Space(20)]
        private UnityEvent<ScreenInfo_Unit> refreshItems;

        private ScreenInfo_Unit attachedData;

        public void Close()
        {
            attachedData.onClose();
            gameObject.SetActive(false);
        }

        public void Enable(object obj)
        {
            attachedData = (ScreenInfo_Unit)obj;
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