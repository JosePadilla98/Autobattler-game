using System;
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