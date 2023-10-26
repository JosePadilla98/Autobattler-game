using AutobattlerOld.InfoPanel;
using AutobattlerOld.Units;
using AutobattlerOld.Units.Management;
using UnityEngine;
using UnityEngine.Events;

namespace AutobattlerOld.Events
{
    public class GameEventListener_Generic : MonoBehaviour
    {
        [Tooltip("Event to register with.")]
        public GameEvent_Generic Event;

        [Tooltip("Response to invoke when Event is raised.")]
        public UnityEvent<object> Response;

        private void OnEnable()
        {
            Event.RegisterListener(this);
        }

        private void OnDisable()
        {
            Event.UnregisterListener(this);
        }

        public void OnEventRaised(object obj)
        {
            Response.Invoke(obj);
        }
    }
}