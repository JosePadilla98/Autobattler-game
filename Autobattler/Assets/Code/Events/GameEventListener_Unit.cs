using Autobattler.Units;
using UnityEngine;
using UnityEngine.Events;

namespace Autobattler.Events
{
    public class GameEventListener_Unit : MonoBehaviour
    {
        [Tooltip("Event to register with.")]
        public GameEvent_Unit Event;

        [Tooltip("Response to invoke when Event is raised.")]
        public UnityEvent<_Unit> Response;

        private void OnEnable()
        {
            Event.RegisterListener(this);
        }

        private void OnDisable()
        {
            Event.UnregisterListener(this);
        }

        public void OnEventRaised(_Unit unit)
        {
            Response.Invoke(unit);
        }
    }
}