using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auttobattler
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField]
        private ItemsInfoPanel itemsInfoPanelInScene;

        private void OnEnable()
        {
            ItemsInfoPanel.Instance = itemsInfoPanelInScene;
        }

        private void OnDisable()
        {
            if (ItemsInfoPanel.Instance.IsShowing)
            {
                ItemsInfoPanel.Instance.UnnatachItem();
            }
            ItemsInfoPanel.Instance = null;
        }
    }
}
