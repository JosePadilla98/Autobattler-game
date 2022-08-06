using System;
using UnityEngine;

namespace Autobattler.GameControllers.Combat
{
    [CreateAssetMenu(fileName = "ConsoleController", menuName = "ScriptableObjects/ConsoleController")]
    public class ConsoleController : ScriptableObject, IConsoleController
    {
        
    }

    public interface IConsoleController
    {
        public void Log(String output)
        {
            Debug.Log(output);
        }
    }
}