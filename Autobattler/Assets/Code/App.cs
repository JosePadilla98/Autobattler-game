using System;
using Autobattler.GameControllers;
using UnityEngine;

namespace Autobattler
{
    public class App : MonoBehaviour
    {
        public RunController runController;

        private void Start()
        {
            runController.Init();
        }
    }
}