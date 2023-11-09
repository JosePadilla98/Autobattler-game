using System;
using AutobattlerOld.Configs;
using AutobattlerOld.GameControllers;
using AutobattlerOld.GameControllers.Combat;
using AutobattlerOld.Grid.Generic;
using AutobattlerOld.Units.Combat;
using UnityEngine;

namespace AutobattlerOld
{
    public class App : MonoBehaviour
    {
        public static GridsController<Fighter> Battlefield =>
            instance != null ? instance.battlefield : null;

        [SerializeField]
        private RunController runController;

        [SerializeField]
        private GridsController<Fighter> battlefield;

        private static App instance;

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
