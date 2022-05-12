using UnityEngine;

namespace Autobattler.InventorySystem
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private ItemsInfoPanel itemsInfoPanelInScene;

        private void OnEnable()
        {
            ItemsInfoPanel.Instance = itemsInfoPanelInScene;
        }

        private void OnDisable()
        {
            if (ItemsInfoPanel.Instance.IsShowing) ItemsInfoPanel.Instance.UnnatachItem();
            ItemsInfoPanel.Instance = null;
        }
    }
}