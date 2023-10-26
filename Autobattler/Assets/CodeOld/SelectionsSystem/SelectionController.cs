﻿using System;
using System.Collections.Generic;
using AutobattlerOld.DragAndDrop;
using AutobattlerOld.Units.Management;
using AutobattlerOld.UnitsListScreen;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace AutobattlerOld.SelectionsSystem
{
    public class SelectionController : MonoBehaviour
    {
        [SerializeField]
        private SelectablesParent[] selectablesParents;
        [SerializeField]
        private bool canBeChildrenUnselectedWithMouse = true;
        [Space(20)]
        public List<SelectableComponent> selectables;
        [Space(20)]
        public UnityEvent<MonoBehaviour> onTargetSelected;
        [Space(20)]
        public UnityEvent onTargedUnselected;
        [Space(20)]
        public UnityEvent OnOneOfMyChildrenSelected;

        protected SelectableComponent currentlySelected;

        private void Awake()
        {
            foreach (var parent in selectablesParents)
            {
                parent.onNewChildAdded += AddNewSelectable;
            }
        }

        private void OnEnable()
        {
            if (selectables.Count > 0 && currentlySelected == null)
                OnOneChildSelected(selectables[0]);
        }

        private void OnDisable()
        {
            currentlySelected = null;
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
                if (canBeChildrenUnselectedWithMouse)
                    Unselect();

                return;
            }

            if (currentlySelected != null)
                Unselect();

            foreach (var selectableChild in selectables)
            {
                if (selectableChild == selected)
                {
                    currentlySelected = selected;
                    selectableChild.Select();
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
            currentlySelected.Deselect();
            currentlySelected = null;
            onTargedUnselected?.Invoke();
        }

        public void TryUnselect()
        {
            if (currentlySelected == null)
                return;

            Unselect();
        }

        public void SelectToTheRight(InputAction.CallbackContext context)
        {
            if (!context.performed)
                return;

            ObjectBeingDragged.CancelDragging();

            var selectedIndex = selectables.IndexOf(currentlySelected);

            selectedIndex++;
            if (selectedIndex == selectables.Count)
                selectedIndex = 0;

            SelectableComponent newSelected = selectables[selectedIndex];
            OnOneChildSelected(newSelected);
        }

        public void SelectToTheLeft(InputAction.CallbackContext context)
        {
            if (!context.performed)
                return;

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