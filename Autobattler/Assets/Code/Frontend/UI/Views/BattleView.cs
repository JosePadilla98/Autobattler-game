using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auttobattler
{
    public class BattleView : MonoBehaviour
    {
        public UnitInfoPanel unitInfoPanel;

        private void OnEnable()
        {
            UnitInfoPanel.Instance = unitInfoPanel;
        }
    }
}
