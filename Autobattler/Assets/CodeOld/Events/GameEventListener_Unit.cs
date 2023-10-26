using AutobattlerOld.Units;
using AutobattlerOld.Units.Management;
using UnityEngine;
using UnityEngine.Events;

namespace AutobattlerOld.Events
{
    public class GameEventListener_Unit : MonoBehaviour
    {
        [Tooltip("Event to register with.")]
        public GameEvent_Unit Event;

        [Tooltip("Response to invoke when Event is raised.")]
        public UnityEvent<Unit> Response;

        private void OnEnable()
        {
            Event.RegisterListener(this);
        }

        private void OnDisable()
        {
            Event.UnregisterListener(this);
        }

        public void OnEventRaised(Unit unit)
        {
            Response.Invoke(unit);
        }
    }
}