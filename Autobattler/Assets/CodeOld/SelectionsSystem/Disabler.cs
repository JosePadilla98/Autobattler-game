﻿using System.Collections.Generic;
using UnityEngine;

namespace AutobattlerOld.SelectionsSystem
{
    public class Disabler : MonoBehaviour
    {
        public List<GameObject> children;

        public void DisableAll()
        {
            foreach (var child in children)
            {
                child.SetActive(false);
            }
        }
    }
}