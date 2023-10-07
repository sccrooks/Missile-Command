using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Sccrooks.Utility.ScriptableObjects.Events
{
    public class GameEventListener : MonoBehaviour
    {
        public GameEvent Event;
        public UnityEvent Response;

        private void OnEnable()
        {
            Event.RegisterListener(this);
        }

        private void OnDisable()
        {
            Event?.UnregisterListener(this);
        }

        public void OnEventRaised()
        {
            Response?.Invoke();
            Debug.Log(gameObject.name);
        }
    }
}