using System.Collections.Generic;
using AutobattlerOld.Units.Management;
using UnityEngine;

namespace AutobattlerOld.Events
{
    [CreateAssetMenu(fileName = "GameEvent_Unit", menuName = "ScriptableObjects/Events/Unit")]
    public class GameEvent_Unit : ScriptableObject
    {
        /// <summary>
        /// The list of listeners that this event will notify if it is raised.
        /// </summary>
        private readonly List<GameEventListener_Unit> eventListeners = new List<GameEventListener_Unit>();

        public void Raise(Unit unit)
        {
            for (int i = eventListeners.Count - 1; i >= 0; i--)
                eventListeners[i].OnEventRaised(unit);
        }

        public void RegisterListener(GameEventListener_Unit listener)
        {
            if (!eventListeners.Contains(listener))
                eventListeners.Add(listener);
        }

        public void UnregisterListener(GameEventListener_Unit listener)
        {
            if (eventListeners.Contains(listener))
                eventListeners.Remove(listener);
        }
    }
}