using System.Collections.Generic;
using Autobattler.InfoPanel;
using Autobattler.Units;
using Autobattler.Units.Management;
using UnityEngine;

namespace Autobattler.Events
{
    [CreateAssetMenu(fileName = "GameEvent_Info", menuName = "ScriptableObjects/Events/Info")]
    public class GameEvent_Info : ScriptableObject
    {
        /// <summary>
        /// The list of listeners that this event will notify if it is raised.
        /// </summary>
        private readonly List<GameEventListener_Info> eventListeners = new List<GameEventListener_Info>();

        public void Raise(TextPanelData info)
        {
            for (int i = eventListeners.Count - 1; i >= 0; i--)
                eventListeners[i].OnEventRaised(info);
        }

        public void RegisterListener(GameEventListener_Info listener)
        {
            if (!eventListeners.Contains(listener))
                eventListeners.Add(listener);
        }

        public void UnregisterListener(GameEventListener_Info listener)
        {
            if (eventListeners.Contains(listener))
                eventListeners.Remove(listener);
        }
    }
}