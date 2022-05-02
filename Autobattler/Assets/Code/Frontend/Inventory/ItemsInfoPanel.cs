using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auttobattler
{
    public class ItemsInfoPanel : MonoBehaviour
    {
        public static ItemsInfoPanel Instance
        {
            get => instance;
            set
            {
                instance = value;
            }
        }
        private static ItemsInfoPanel instance;

        public bool IsShowing { get => isShowing; }
        private bool isShowing;

        public void AttachItem()
        {

        }

        public void UnnatachItem()
        {

        }
    }
}
