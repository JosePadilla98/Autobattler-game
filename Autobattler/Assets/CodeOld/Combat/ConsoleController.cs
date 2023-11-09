using System;
using UnityEngine;

namespace AutobattlerOld
{
    [CreateAssetMenu(
        fileName = "ConsoleController",
        menuName = "ScriptableObjects/ConsoleController"
    )]
    public class CombatConsole : ScriptableObject, IConsoleController { }

    public interface IConsoleController
    {
        public void Log(String output)
        {
            Debug.Log(output);
        }
    }
}
