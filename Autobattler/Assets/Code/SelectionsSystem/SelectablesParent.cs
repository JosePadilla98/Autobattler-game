using System;
using UnityEngine;

namespace Autobattler.SelectionSystem
{
    public class SelectablesParent : MonoBehaviour
    {
        public Action<SelectableComponent> onNewChildAdded;

        private void OnTransformChildrenChanged()
        {
            if (transform.childCount == 0)
                return;

            SelectableComponent selectable = GetLastChild().GetComponent<SelectableComponent>();

            if (selectable == null)
                throw new Exception("You are adding children to 'selectablesParent' that not have selectableComponent");

            onNewChildAdded.Invoke(selectable);
        }

        private Transform GetLastChild()
        {
            return transform.GetChild(transform.childCount - 1);
        }
    }
}