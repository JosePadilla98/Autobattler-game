﻿using Autobattler.InfoPanel;
using Autobattler.Units;
using Autobattler.Units.Management;
using UnityEngine;
using UnityEngine.Events;

namespace Autobattler.Events
{
    public class GameEventListener_Info : MonoBehaviour
    {
        [Tooltip("Event to register with.")]
        public GameEvent_Info Event;

        [Tooltip("Response to invoke when Event is raised.")]
        public UnityEvent<TextPanelData> Response;

        private void OnEnable()
        {
            Event.RegisterListener(this);
        }

        private void OnDisable()
        {
            Event.UnregisterListener(this);
        }

        public void OnEventRaised(TextPanelData info)
        {
            Response.Invoke(info);
        }
    }
}