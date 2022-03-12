using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace auttobattler
{
    public class CanvasSingleton : MonoBehaviour
    {
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

        private void Awake()
        {
            Instance = GetComponent<Canvas>();
        }
    }
}