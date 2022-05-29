using UnityEngine;
using UnityEngine.UI;

namespace Autobattler.InventorySystem
{
    public class ItemView : MonoBehaviour
    {
        public Image image;
        public Item item;

        public void InyectDependencies(Sprite sprite, Item item)
        {
            image.sprite = sprite;
            this.item = item;
        }
    }
}