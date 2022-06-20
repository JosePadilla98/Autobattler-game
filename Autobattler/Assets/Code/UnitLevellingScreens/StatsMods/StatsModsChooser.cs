using Autobattler.Units.Management;
using UnityEngine;

namespace Autobattler.UnitLevellingScreens
{
    public class StatsModsChooser : MonoBehaviour
    {
        [SerializeField]
        private StatModView statModViewPrefab;
        [SerializeField] 
        private Transform listParents;

        public void Enable(Unit unit)
        {
            var expModule = (unit as PlayerUnit).expModule;
            var statsMods = expModule.StatsManager.GetCurrentElements();

            foreach (var stadMod in statsMods)
            {
                var statModView = Instantiate(statModViewPrefab, listParents);
                statModView.Inflate(stadMod);
            }
        }
    }
}