using Autobattler.Events;
using Autobattler.Screens;
using UnityEngine;
using UnityEngine.Events;

namespace Autobattler.UnitLevellingScreens
{
    public class MutationsBonusesScreen : MonoBehaviour
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