using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Sccrooks.Utility.ScriptableObjects.Events
{
    public class GameEventListener : MonoBehaviour
    {
        [Header("Logging")]
        [SerializeField] private bool _logEvent = false;

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

            if (_logEvent)
                Debug.Log(gameObject.name);
        }
    }
}