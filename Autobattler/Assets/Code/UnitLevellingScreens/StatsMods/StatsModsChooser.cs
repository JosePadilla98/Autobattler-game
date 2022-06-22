using System;
using System.Collections.Generic;
using System.Text;
using Autobattler.ExpModule.Stats;
using Autobattler.Units.Management;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Autobattler.UnitLevellingScreens
{
    public class StatsModsChooser : MonoBehaviour
    {
        [SerializeField]
        private StatModView statModViewPrefab;
        [SerializeField] 
        private Transform listParents;
        [SerializeField]
        private TextMeshProUGUI title;
        [SerializeField]
        private TextMeshProUGUI subtitle;
        [SerializeField]
        private UnityEvent<bool> refreshSaveButton;
        [SerializeField]
        private UnityEvent refreshParent;

        private List<StatModView> children = new();
        private List<StatModView> selectedItems = new();

        private int choicesNum;
        private StringBuilder builder = new StringBuilder();

        private StatsPacksManager statsPacksManager;

        public void Enable(Unit unit)
        {
            statsPacksManager = (unit as PlayerUnit).expModule.StatsManager;
            var statsMods = statsPacksManager.GetCurrentElements();

            choicesNum = statsPacksManager.CurrentPackOpened.model.roundData.choicesNum;
            RefreshTitlte();
            RefreshSubtitle();

            foreach (var stadMod in statsMods)
            {
                var statModView = Instantiate(statModViewPrefab, listParents);
                statModView.Inflate(stadMod,this);
                children.Add(statModView);
            }
        }

        public void RefreshTitlte()
        {
            builder.Clear();
            builder.AppendFormat("Pick {0} modification:", choicesNum);
            title.text = builder.ToString();
        }

        public void RefreshSubtitle()
        {
            //subtitle
            builder.Clear();
            builder.AppendFormat("({0}/{1} picked)", selectedItems.Count, choicesNum);
            subtitle.text = builder.ToString();
        }

        public void Disable()
        {
            for (int i = children.Count -1; i >= 0; i--)
            {
                Destroy(children[i].gameObject);
            }

            selectedItems.Clear();
            children.Clear();
        }

        public void OnChildSelected(StatModView statModView)
        {
            ProcessSelection();
            RefreshSubtitle();
            RefreshSaveButton();

            void ProcessSelection()
            {
                //Deselect
                if (selectedItems.Contains(statModView))
                {
                    selectedItems.Remove(statModView);
                    statModView.Deselect();
                    return;
                }

                //Select
                if (selectedItems.Count < choicesNum)
                {
                    selectedItems.Add(statModView);
                    statModView.Select();
                    return;
                }

                //Select the new but unselect the first selected
                selectedItems.Add(statModView);
                statModView.Select();
                var firstSelected = selectedItems[0];
                firstSelected.Deselect();
                selectedItems.RemoveAt(0);
            }
        }

        private void RefreshSaveButton()
        {
            refreshSaveButton.Invoke((selectedItems.Count == choicesNum));
        }

        public void Save()
        {
            statsPacksManager.CurrentPackOpened.currentRound.SaveSelection(selectedItems);
            Disable();
            refreshParent?.Invoke();
        }

        public void SelectNone()
        {
            statsPacksManager.CurrentPackOpened.currentRound.SaveSelection(null);
            Disable();
            refreshParent?.Invoke();
        }

        private void OnDisable()
        {
            Disable();
        }
    }
}