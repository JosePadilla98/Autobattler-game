using System;
using System.Collections.Generic;
using UnityEngine;

namespace AutobattlerOld.Events
{
    [CreateAssetMenu(fileName = "GameEvent_Action", menuName = "ScriptableObjects/Events/Action")]
    public class GameEvent_Action : ScriptableObject
    {
        /// <summary>
        /// The list of listeners that this event will notify if it is raised.
        /// </summary>
        private readonly List<GameEventListener_Action> eventListeners = new List<GameEventListener_Action>();

        public void Raise(Action action)
        {
            for (int i = eventListeners.Count - 1; i >= 0; i--)
                eventListeners[i].OnEventRaised(action);
        }

        public void RegisterListener(GameEventListener_Action listener)
        {
            if (!eventListeners.Contains(listener))
                eventListeners.Add(listener);
        }

        public void UnregisterListener(GameEventListener_Action listener)
        {
            if (eventListeners.Contains(listener))
                eventListeners.Remove(listener);
        }
    }
}