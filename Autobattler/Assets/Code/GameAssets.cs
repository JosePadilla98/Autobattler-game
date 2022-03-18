using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auttobattler
{
    public class GameAssets : MonoBehaviour
    {
        public NumberPopup damagePopup;
        public Unit unitPrefab;

        #region SINGLETON

        private static GameAssets instance;
        public static GameAssets Instance
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
            Instance = GetComponent<GameAssets>();
        }
    }
}
