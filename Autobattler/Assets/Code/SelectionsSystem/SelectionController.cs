using System;
using System.Collections.Generic;
using Autobattler.DragAndDrop;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Autobattler.SelectionSystem
{
    public class SelectionController : MonoBehaviour
    {
        [SerializeField]
        private SelectablesParent[] selectablesParents;
        [SerializeField]
        private bool selectFirstAtBeginning;
        [Space(20)]
        public List<SelectableComponent> selectables;
        [Space(20)]
        public UnityEvent<MonoBehaviour> onTargetSelected;
        [Space(20)]
        public UnityEvent onTargedUnselected;
        [Space(20)]
        public UnityEvent OnOneOfMyChildrenSelected;

        private SelectableComponent currentlySelected;

        private void Awake()
        {
            foreach (var parent in selectablesParents)
            {
                parent.onNewChildAdded += AddNewSelectable;
            }
        }

        private void Start()
        {
            if(selectFirstAtBeginning && selectables.Count > 0)
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
            if (currentlySelected != null && currentlySelected == selected)
            {
                Unselect();
                return;
            }

            if(currentlySelected != null)
                Unselect();

            foreach (var selectableChild in selectables)
            {
                if (selectableChild == selected)
                {
                    currentlySelected = selected;
                    selectableChild.WhenSelected();
                    onTargetSelected.Invoke(selected.target);
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

        public void Unselect()
        {
            currentlySelected.WhenUnselect();
            currentlySelected = null;
            onTargedUnselected?.Invoke();
        }

        public void SelectToTheRight()
        {
            ObjectBeingDragged.CancelDragging();

            var selectedIndex = selectables.IndexOf(currentlySelected);

            selectedIndex++;
            if (selectedIndex == selectables.Count)
                selectedIndex = 0;

            SelectableComponent newSelected = selectables[selectedIndex];
            OnOneChildSelected(newSelected);
        }

        public void SelectToTheLeft()
        {
            ObjectBeingDragged.CancelDragging();

            var selectedIndex = selectables.IndexOf(currentlySelected);

            selectedIndex--;
            if (selectedIndex == -1)
                selectedIndex = selectables.Count - 1;

            SelectableComponent newSelected = selectables[selectedIndex];
            OnOneChildSelected(newSelected);
        }
    }
}