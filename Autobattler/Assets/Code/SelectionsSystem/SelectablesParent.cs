using System;
using System.Collections.Generic;
using UnityEngine;

namespace Autobattler.SelectionsSystem
{
    public class SelectablesParent : MonoBehaviour
    {
        public Action<SelectableComponent> onNewChildAdded;
        private List<SelectableComponent> childs;

        public List<SelectableComponent> Childs
        {
            get
            {
                if (childs == null)
                    childs = new();

                return childs;
            }
        }

        private void OnTransformChildrenChanged()
        {
            if (transform.childCount == 0)
                return;

            foreach (var selectable in GetComponentsInChildren<SelectableComponent>())
            {
                if(!Childs.Contains(selectable))
                {
                    Childs.Add(selectable);
                    selectable.onDestroy += OnChildDestroyed;
                    onNewChildAdded.Invoke(selectable);
                }
            }
        }

        private void OnChildDestroyed(SelectableComponent child)
        {
            childs.Remove(child);
        }
    }
}