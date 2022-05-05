using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Auttobattler
{
    //TODO Arreglar esto, hacerlo en condiciones
    public class NumberPopupPool : MonoBehaviour
    {
        private static ObjectPool<NumberPopup> pool;

        private void Awake()
        {
            Func<NumberPopup> createFunc = () => {

                return Instantiate(GameAssets.Instance.damagePopup); 
            };


            Action<NumberPopup> actionOnGet = (popup) => {

            };

            pool = new ObjectPool<NumberPopup>(() => { return Instantiate(GameAssets.Instance.damagePopup); });
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