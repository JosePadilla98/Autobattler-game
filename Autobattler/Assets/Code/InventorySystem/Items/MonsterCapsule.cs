using UnityEngine;

namespace Autobattler.InventorySystem.Items
{
    [CreateAssetMenu(fileName = "MonsterCapsule", menuName = "ScriptableObjects/Items/MonsterCapsule")]
    public class MonsterCapsule : ItemScriptable, Item
    {
        public override void OnClick()
        {

        }
    }

    public abstract class ItemScriptable : ScriptableObject
    {
        public abstract void OnClick();
    }

    public interface Item
    {
        public void OnClick();
    }
}