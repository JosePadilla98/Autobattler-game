using Autobattler.Units.Combat;
using UnityEngine;
using UnityEngine.Events;

namespace Autobattler.Events
{
    public class GameEventListener_Fighter : MonoBehaviour
    {
        [Tooltip("Event to register with.")]
        public GameEvent_Fighter Event;

        [Tooltip("Response to invoke when Event is raised.")]
        public UnityEvent<Fighter> Response;

        private void OnEnable()
        {
            Event.RegisterListener(this);
        }

        private void OnDisable()
        {
            Event.UnregisterListener(this);
        }

        public void OnEventRaised(Fighter fighter)
        {
            Response.Invoke(fighter);
        }
    }
}