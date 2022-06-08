using Autobattler.Grid.Logic;
using Autobattler.ScriptableCollections;
using Autobattler.Units.Management;
using UnityEngine;

namespace Autobattler.Grid.Views
{
    public class Slot_U_View : MonoBehaviour
    {
        public Slot_U logic;
        public Battefield_U_View battlefieldView;
        public UnitsCollection playerUnitsInGrid => battlefieldView.playerUnitsInGrid;

        public Side Side => logic.GetSide();

        public UnitView unitViewPrefab => battlefieldView.unitViewPrefab;
        public UnitView playerUnitViewPrefab => battlefieldView.playerUnitViewPrefab;

        private void Awake()
        {
            logic.OnNewItemBuilded += BuildUnitView;
        }

        private void BuildUnitView(Unit unit)
        {
            UnitView unitView = Instantiate(PrefabToInstantiate(), transform);
            unitView.InyectDependences(unit);

            if (Side == Side.RIGHT)
            {
                unitView.image.transform.localScale = new Vector3(-1, 1, 1);
            }
        }

        public void UnattachUnit(MonoBehaviour target)
        {
            UnitView unitView = target as UnitView;

            logic.UnnatachItem();
            playerUnitsInGrid.Collection.Remove(unitView.unit);

            #if UNITY_EDITOR || DEVELOPMENT_BUILD

            if (App.DebugController != null && App.DebugController.unitsGridDebug)
                Debug.Log(unitView.unit.name + " unattached in grid");

            #endif
        }

        public void AttachUnit(MonoBehaviour target)
        {
            UnitView unitView = target as UnitView;

            logic.AttachItem(unitView.unit);
            playerUnitsInGrid.Collection.Add(unitView.unit);

            #if UNITY_EDITOR || DEVELOPMENT_BUILD

            if (App.DebugController != null && App.DebugController.unitsGridDebug)
                Debug.Log(unitView.unit.name + " attached in grid");

            #endif
        }

        private UnitView PrefabToInstantiate()
        {
            if (Side == Side.LEFT)
                return playerUnitViewPrefab;

            return unitViewPrefab;
        }
    }
}