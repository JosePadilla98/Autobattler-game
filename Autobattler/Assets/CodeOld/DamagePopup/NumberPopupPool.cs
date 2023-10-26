using System;
using UnityEngine;
using UnityEngine.Pool;

namespace AutobattlerOld.DamagePopup
{
    //TODO Arreglar esto, hacerlo en condiciones
    public class NumberPopupPool : MonoBehaviour
    {
        private static ObjectPool<NumberPopup> pool;

        private void Awake()
        {
            Func<NumberPopup> createFunc = () => { return null;/*Instantiate(GameAssets.Instance.damagePopup);*/ };


            Action<NumberPopup> actionOnGet = popup => { };

            pool = new ObjectPool<NumberPopup>(() => { return null; });
        }

        public static NumberPopup Get()
        {
            return pool.Get();
        }

        public static void Release(NumberPopup popup)
        {
            pool.Release(popup);
        }
    }
}