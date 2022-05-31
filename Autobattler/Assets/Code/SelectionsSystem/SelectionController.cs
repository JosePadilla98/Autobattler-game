using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

        private void Awake()
        {
            selectablesParent.onNewChildAdded += AddNewSelectable;
        }

        public void AddNewSelectable(SelectableComponent selectable)
        {
            selectables.Add(selectable);
            selectable.onSelected += OnOneChildSelected;
        }

        public void OnOneChildSelected(SelectableComponent selectable)
        {
            foreach (var s in selectables)
            {
                s.Unselect();
            }

            selectable.Select();

            Debug.Log("selected");
        }
    }
}