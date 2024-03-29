﻿using System;
using Autobattler.Configs;
using Autobattler.DragAndDrop;
using Autobattler.Events;
using UnityEngine;

namespace Autobattler.Screens
{
    public class UnitsScreen : MonoBehaviour
    {
        [SerializeField]
        private KeyModel openUnitsScreenKeyModel;

        private Action comeBackToLastScreen;

        public void Update()
        {
            if (Input.GetKeyDown(openUnitsScreenKeyModel.key))
            {
                comeBackToLastScreen.Invoke();
                gameObject.SetActive(false);
                ObjectBeingDragged.CancelDragging();
            }
        }

        public void Enable(Action comeBackToLastScreen)
        {
            this.comeBackToLastScreen = comeBackToLastScreen;
            gameObject.SetActive(true);
        }
    }
}