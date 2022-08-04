using System;
using Autobattler.Configs;
using Autobattler.GameControllers;
using UnityEngine;

namespace Autobattler
{
    public class App : MonoBehaviour
    {
        public RunController runController;
        public DebugController debugController;

        private static App instance;
        public static App Instance => instance;
        public static DebugController DebugController => instance != null ? instance.debugController : null;

        private void Awake()
        {
            if (instance)
                throw new Exception("This should never happen");

            instance = this;
        }

        private void Start()
        {
            runController.Init();
        }

        public void FixedUpdate()
        {
            runController.Refresh();
        }
    }
}