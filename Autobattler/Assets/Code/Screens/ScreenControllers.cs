using System;
using Autobattler.Events;
using UnityEngine;

namespace Autobattler.Screens
{
    public class ScreenControllers : MonoBehaviour
    {
        public GameObject combatScreen;

        private void Awake()
        {
            combatScreen.SetActive(true);
            combatScreen.SetActive(false);
        }

        public void OnCombatInit()
        {
            combatScreen.SetActive(true);
        }
    }
}