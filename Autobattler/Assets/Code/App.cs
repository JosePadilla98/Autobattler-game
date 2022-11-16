﻿using System;
using Autobattler.Configs;
using Autobattler.GameControllers;
using Autobattler.GameControllers.Combat;
using Autobattler.Grid.Generic;
using Autobattler.Units.Combat;
using UnityEngine;

namespace Autobattler
{
    public class App : MonoBehaviour
    {
        public RunController runController;
        public DebugController debugController;
        [SerializeField]
        private ConsoleController combatConsole;
        [SerializeField]
        private GridsController<Fighter> battlefield;


        private static App instance;
        public static App Instance => instance;
        public static DebugController DebugController => instance != null ? instance.debugController : null;
        public static IConsoleController CombatConsole => instance != null ? instance.combatConsole : null;
        public static GridsController<Fighter> Battlefield => instance != null ? instance.battlefield : null;


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

    public interface IEntityInGrid
    {

    }
}