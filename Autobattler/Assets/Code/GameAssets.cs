using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auttobattler
{
    public class GameAssets : MonoBehaviour
    {
        [Header("Prefabs")]
        public NumberPopup damagePopup;
        public Unit unitPrefab;

        [Space(10)]
        [Header("Configs")]
        public ColorPalette colorPalette;

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
