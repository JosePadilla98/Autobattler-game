using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Autobattler.SelectionSystem
{
    public class SelectionController : MonoBehaviour
    {
        [SerializeField]
        private SelectablesParent selectablesParent;
        [Space(20)]
        public List<SelectableComponent> selectables;
        [Space(20)]
        public UnityEvent<MonoBehaviour> onComponentSelected;
        [Space(20)]
        public UnityEvent OnOneOfMyChildrenSelected;

        private int selectedIndex;

        private void Awake()
        {
            selectablesParent.onNewChildAdded += AddNewSelectable;
        }

        private void Start()
        {
            OnOneChildSelected(selectables[0]);
        }

        public void AddNewSelectable(SelectableComponent selectable)
        {
            selectables.Add(selectable);
            selectable.onSelected += OnOneChildSelected;
        }

        public void OnOneChildSelected(SelectableComponent selected)
        {
            for (int i = 0; i < selectables.Count; i++)
            {
                var s = selectables[i];

                if (s == selected)
                {
                    selectedIndex = i;
                    s.Select();
                    onComponentSelected.Invoke(selected.target);
                }
                else
                {
                    s.Unselect();
                }
            }

            OnOneOfMyChildrenSelected?.Invoke();
        }

        public void SelectToTheRight()
        {
            selectedIndex++;
            if (selectedIndex == selectables.Count)
                selectedIndex = 0;

            SelectableComponent newSelected = selectables[selectedIndex];
            OnOneChildSelected(newSelected);
        }

        public void SelectToTheLeft()
        {
            selectedIndex--;
            if (selectedIndex == -1)
                selectedIndex = selectables.Count - 1;

            SelectableComponent newSelected = selectables[selectedIndex];
            OnOneChildSelected(newSelected);
        }
    }
}