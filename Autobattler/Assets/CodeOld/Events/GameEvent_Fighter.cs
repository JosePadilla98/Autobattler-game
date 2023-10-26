using System.Collections.Generic;
using AutobattlerOld.Units.Combat;
using UnityEngine;

namespace AutobattlerOld.Events
{
    [CreateAssetMenu(fileName = "GameEvent_Fighter", menuName = "ScriptableObjects/Events/Fighter")]
    public class GameEvent_Fighter : ScriptableObject
    {
        /// <summary>
        /// The list of listeners that this event will notify if it is raised.
        /// </summary>
        private readonly List<GameEventListener_Fighter> eventListeners = new List<GameEventListener_Fighter>();

        public void Raise(Fighter fighter)
        {
            for (int i = eventListeners.Count - 1; i >= 0; i--)
                eventListeners[i].OnEventRaised(fighter);
        }

        public void RegisterListener(GameEventListener_Fighter listener)
        {
            if (!eventListeners.Contains(listener))
                eventListeners.Add(listener);
        }

        public void UnregisterListener(GameEventListener_Fighter listener)
        {
            if (eventListeners.Contains(listener))
                eventListeners.Remove(listener);
        }
    }
}