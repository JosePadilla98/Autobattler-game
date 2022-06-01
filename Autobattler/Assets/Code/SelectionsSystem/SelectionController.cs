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
        [SerializeField]
        private bool selectFirstAtBeginning;
        [Space(20)]
        public List<SelectableComponent> selectables;
        [Space(20)]
        public UnityEvent<MonoBehaviour> onTargetSelected;
        [Space(20)]
        public UnityEvent OnOneOfMyChildrenSelected;

        private int selectedIndex;
      

        private void Awake()
        {
            selectablesParent.onNewChildAdded += AddNewSelectable;
            selectedIndex = 0;
        }

        private void Start()
        {
            if(selectFirstAtBeginning)
                OnOneChildSelected(selectables[0]);
        }

        public void AddNewSelectable(SelectableComponent selectable)
        {
            selectables.Add(selectable);
            selectable.onSelected += OnOneChildSelected;
            selectable.onDestroy += BeforeChildGetDestroyed;
        }

        public void OnOneChildSelected(SelectableComponent selected)
        {
            for (int i = 0; i < selectables.Count; i++)
            {
                var s = selectables[i];

                if (s == selected)
                {
                    selectedIndex = i;
                    s.WhenSelected();
                    onTargetSelected.Invoke(selected.target);
                }
                else
                {
                    s.WhenUnselect();
                }
            }

            OnOneOfMyChildrenSelected?.Invoke();
        }

        private void BeforeChildGetDestroyed(SelectableComponent selectable)
        {
            selectables.Remove(selectable);
            selectable.onSelected -= OnOneChildSelected;
            selectable.onDestroy -= BeforeChildGetDestroyed;

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