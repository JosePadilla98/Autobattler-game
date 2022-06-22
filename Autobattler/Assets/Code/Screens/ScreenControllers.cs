using System;
using Autobattler.Events;
using UnityEngine;

namespace Autobattler.Screens
{
    public class ScreenControllers : MonoBehaviour
    {
        public GameObject mainScreen;
        public GameObject[] otherScreens;

        private void Awake()
        {
            //foreach (var screen in otherScreens)
            //{
            //    screen.SetActive(false);
            //    screen.SetActive(true);
            //    screen.SetActive(false);
            //}

            mainScreen.SetActive(true);
        }
    }
}