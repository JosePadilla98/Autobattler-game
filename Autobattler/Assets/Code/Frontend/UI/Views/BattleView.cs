using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auttobattler
{
    public class BattleView : MonoBehaviour
    {
        [SerializeField]
        private UnitInfoPanel unitInfoPanelInScene;

        private void OnEnable()
        {
            UnitInfoPanel.Instance = unitInfoPanelInScene;
        }

        private void OnDisable()
        {
            if (UnitInfoPanel.Instance.IsShowing)
            {
                UnitInfoPanel.Instance.UnattachUnit();
            }
            UnitInfoPanel.Instance = null;
        }
    }
}
