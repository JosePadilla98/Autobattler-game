using System;
using Autobattler.Grid.Logic;
using Autobattler.Grid.Views;
using Autobattler.ScriptableCollections;
using Autobattler.Units;
using UnityEngine;

namespace Autobattler.Grid.ManagementState
{
    public class Slot_U_View : MonoBehaviour
    {
        public Slot_U logic;
        public Battefield_U_View battlefieldView;
        public UnitsCollection playerUnitsInGrid => battlefieldView.playerUnitsInGrid;

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

        internal void UnattachUnit(UnitView unitView)
        {
            logic.UnnatachItem();
            playerUnitsInGrid.Collection.Remove(unitView.unit);
        }

        public void AttachUnit(UnitView unitView)
        {
            logic.AttachItem(unitView.unit);
            playerUnitsInGrid.Collection.Add(unitView.unit);
        }

        private UnitView PrefabToInstantiate()
        {
            if (Side == Side.LEFT)
                return playerUnitViewPrefab;

            return unitViewPrefab;
        }
    }
}