using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auttobattler
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