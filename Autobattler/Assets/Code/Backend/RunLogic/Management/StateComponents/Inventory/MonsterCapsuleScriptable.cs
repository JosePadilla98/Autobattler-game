using UnityEngine;

namespace Auttobattler.Backend
{
    [CreateAssetMenu(fileName = "MonsterCapsule", menuName = "ScriptableObjects/Items/MonsterCapsule")]
    public class MonsterCapsuleScriptable : ItemScriptable, Item
    {
        public MonsterCapsule monsterCapsule;

        public override void OnClick()
        {
            Debug.Log("hola");
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
