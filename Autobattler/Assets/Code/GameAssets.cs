using Auttobattler.Frontend;
using UnityEngine;

namespace Auttobattler
{
    public class GameAssets : MonoBehaviour
    {
        [Header("Prefabs")]
        public NumberPopup damagePopup;
        public UnitView unitView;

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
