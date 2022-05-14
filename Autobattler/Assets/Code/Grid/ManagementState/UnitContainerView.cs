using Autobattler.Units;
using UnityEngine;

namespace Autobattler.Grid.ManagementState
{
    public class UnitContainerView : MonoBehaviour
    {
        public UnitContainer unitContainer;
        public Battefield_U_View battlefieldView;

        public Side Side
        {
            get => unitContainer.GetSide();
        }

        public UnitView unitViewPrefab => battlefieldView.unitViewPrefab;
        public UnitView playerUnitViewPrefab => battlefieldView.playerUnitViewPrefab;

        private void Awake()
        {
            unitContainer.onItemAttached += BuilUnitView;
        }

        private void BuilUnitView(Unit unit)
        {
            UnitView unitView = Instantiate(unitViewPrefab, transform);

            if (Side == Side.RIGHT)
            {
                unitView.image.transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }
}