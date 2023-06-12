using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Infrastructure.ScriptableObjects.Events
{
    public class DataGameEventListener<T> : MonoBehaviour
    {
        public DataGameEvent<T> Event;
        public GenericEvent<T> Response;

        private void OnEnable()
        {
            Event.RegisterListener(this);
        }

        private void OnDisable()
        {
            Event.UnregisterListener(this);
        }

        public void OnEventRaised(T data)
        {
            Response.Invoke(data);
        }
    }
}