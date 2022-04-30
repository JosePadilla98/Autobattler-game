using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auttobattler
{
    public class CanvasSingleton : MonoBehaviour
    {
        #region SINGLETON

        private static Canvas instance;
        public static Canvas Instance
        {
            get => instance;
            set
            {
                if (instance != null)
                    throw new System.Exception("Must be only one");

                instance = value;
            }
        }

        #endregion 

        private void Awake()
        {
            Instance = GetComponent<Canvas>();
        }
    }
}