using System.Collections.Generic;
using UnityEngine;

namespace AutobattlerOld.Events
{
    [CreateAssetMenu(fileName = "GameEvent_Generic", menuName = "ScriptableObjects/Events/Generic")]
    public class GameEvent_Generic : ScriptableObject
    {
        /// <summary>
        /// The list of listeners that this event will notify if it is raised.
        /// </summary>
        private readonly List<GameEventListener_Generic> eventListeners = new List<GameEventListener_Generic>();

        public void Raise(object obj)
        {
            for (int i = eventListeners.Count - 1; i >= 0; i--)
                eventListeners[i].OnEventRaised(obj);
        }

        public void RegisterListener(GameEventListener_Generic listener)
        {
            if (!eventListeners.Contains(listener))
                eventListeners.Add(listener);
        }

        public void UnregisterListener(GameEventListener_Generic listener)
        {
            if (eventListeners.Contains(listener))
                eventListeners.Remove(listener);
        }
    }
}