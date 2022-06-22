using System;
using System.Collections.Generic;
using System.Text;
using Autobattler.ExpModule.Stats;
using Autobattler.Units.Management;
using TMPro;
using UnityEngine;

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

        public List<StatModView> children = new();
        private List<StatModView> selectedItems = new();

        private int choicesNum;
        private StringBuilder builder = new StringBuilder();

        public void Enable(Unit unit)
        {
            var statsManager = (unit as PlayerUnit).expModule.StatsManager;
            var statsMods = statsManager.GetCurrentElements();

            //title
            choicesNum = statsManager.CurrentPackOpened.model.roundData.choicesNum;
            builder.AppendFormat("Pick {0} modification:", choicesNum);
            title.text = builder.ToString();

            RefreshSubtitle();

            foreach (var stadMod in statsMods)
            {
                var statModView = Instantiate(statModViewPrefab, listParents);
                statModView.Inflate(stadMod,this);
                children.Add(statModView);
            }
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

        public bool canPassNext()
        {
            return (selectedItems.Count == choicesNum);
        }

    }
}