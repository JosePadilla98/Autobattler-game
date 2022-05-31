using System;
using UnityEngine;

namespace Autobattler.SelectionSystem
{
    public class SelectablesParent : MonoBehaviour
    {
        public Action<SelectableComponent> onNewChildAdded;

        private void OnTransformChildrenChanged()
        {
            onNewChildAdded.Invoke(GetLastChild().GetComponent<SelectableComponent>());
        }

        private Transform GetLastChild()
        {
            return transform.GetChild(transform.childCount - 1);
        }
    }
}