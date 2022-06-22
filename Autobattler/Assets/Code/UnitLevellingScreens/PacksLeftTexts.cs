using System.Text;
using Autobattler.Units.Management;
using TMPro;
using UnityEngine;

namespace Autobattler.UnitLevellingScreens
{
    public class PacksLeftTexts : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI statsLeft;
        [SerializeField]
        private TextMeshProUGUI mutationsLeft;

        private StringBuilder builder = new();

        public void Enable(Unit unit)
        {
            var expModule = (unit as PlayerUnit).expModule;

            var statsModPacksLeft = expModule.StatsManager.UnopenedPacksLeft;
            builder.AppendFormat("{0} Stats mods left", statsModPacksLeft.ToString());
            statsLeft.text = builder.ToString();

            builder.Clear();
        }
    }
}