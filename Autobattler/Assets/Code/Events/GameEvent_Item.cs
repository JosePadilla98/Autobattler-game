using System.Collections.Generic;
using Autobattler.InventorySystem;
using UnityEngine;

namespace Autobattler.Events
{
    [CreateAssetMenu(fileName = "GameEvent_Item", menuName = "ScriptableObjects/Events/Item")]
    public class GameEvent_Item : ScriptableObject
    {
        /// <summary>
        /// The list of listeners that this event will notify if it is raised.
        /// </summary>
        private readonly List<GameEventListener_Item> eventListeners = new List<GameEventListener_Item>();

        public void Raise(Item item)
        {
            for (int i = eventListeners.Count - 1; i >= 0; i--)
                eventListeners[i].OnEventRaised(item);
        }

        public void RegisterListener(GameEventListener_Item listener)
        {
            if (!eventListeners.Contains(listener))
                eventListeners.Add(listener);
        }

        public void UnregisterListener(GameEventListener_Item listener)
        {
            if (eventListeners.Contains(listener))
                eventListeners.Remove(listener);
        }
    }
}