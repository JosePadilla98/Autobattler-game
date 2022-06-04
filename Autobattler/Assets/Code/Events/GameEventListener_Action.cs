using System;
using Autobattler.Units.Combat;
using UnityEngine;
using UnityEngine.Events;

namespace Autobattler.Events
{
    public class GameEventListener_Action : MonoBehaviour
    {
        [Tooltip("Event to register with.")]
        public GameEvent_Action Event;

        [Tooltip("Response to invoke when Event is raised.")]
        public UnityEvent<Action> Response;

        private void OnEnable()
        {
            Event.RegisterListener(this);
        }

        private void OnDisable()
        {
            Event.UnregisterListener(this);
        }

        public void OnEventRaised(Action action)
        {
            Response.Invoke(action);
        }
    }
}