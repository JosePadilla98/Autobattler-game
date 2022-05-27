using System;
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
            logic.OnNewItemBuilded += BuildUnitView;
        }

        private void BuildUnitView(_Unit unit)
        {
            UnitView unitView = Instantiate(PrefabToInstantiate(), transform);
            unitView.InyectDependences(unit, battlefieldView.canvas);

            if (Side == Side.RIGHT)
            {
                unitView.image.transform.localScale = new Vector3(-1, 1, 1);
            }
        }

        internal void UnattachUnit()
        {
            logic.UnnatachItem();
        }

        public void AttachUnit(UnitView unitView)
        {
            logic.AttachItem(unitView.unit);
        }

        private UnitView PrefabToInstantiate()
        {
            if (Side == Side.LEFT)
                return playerUnitViewPrefab;

            return unitViewPrefab;
        }
    }
}