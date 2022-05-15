using Autobattler.Units;
using UnityEngine;

namespace Autobattler.Grid.ManagementState
{
    public class Slot_U_View : MonoBehaviour
    {
        public Slot_U logic;
        public Battefield_U_View battlefieldView;

        public Side Side
        {
            get => logic.GetSide();
        }

        public UnitView unitViewPrefab => battlefieldView.unitViewPrefab;
        public UnitView playerUnitViewPrefab => battlefieldView.playerUnitViewPrefab;

        private void Awake()
        {
            logic.onItemAttached += BuildUnitView;
        }

        private void BuildUnitView(Unit unit)
        {
            UnitView unitView = Instantiate(unitViewPrefab, transform);
            unitView.InyectDependences(unit, battlefieldView.canvas);

            if (Side == Side.RIGHT)
            {
                unitView.image.transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }
}