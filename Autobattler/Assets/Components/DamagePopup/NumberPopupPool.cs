using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Auttobattler
{
    public class NumberPopupPool : MonoBehaviour
    {
        private static ObjectPool<NumberPopup> pool;

        private void Awake()
        {
            pool = new ObjectPool<NumberPopup>(() => { return Instantiate(GameAssets.Instance.damagePopup); });
        }

        public static NumberPopup Get()
        {
            Debug.Log(pool.CountAll);
            return pool.Get();
        }

        public static void ReleasePopup(NumberPopup popup)
        {
            pool.Release(popup);
        }
    }
}