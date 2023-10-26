﻿using AutobattlerOld.InventorySystem;
using UnityEngine;
using UnityEngine.Events;

namespace AutobattlerOld.Events
{
    public class GameEventListener_Item : MonoBehaviour
    {
        [Tooltip("Event to register with.")]
        public GameEvent_Item Event;

        [Tooltip("Response to invoke when Event is raised.")]
        public UnityEvent<Item> Response;

        private void OnEnable()
        {
            Event.RegisterListener(this);
        }

        private void OnDisable()
        {
            Event.UnregisterListener(this);
        }

        public void OnEventRaised(Item item)
        {
            Response.Invoke(item);
        }
    }
}