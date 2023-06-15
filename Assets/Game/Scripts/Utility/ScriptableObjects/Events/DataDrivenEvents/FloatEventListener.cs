using MissileCommand.Infrastructure.ScriptableObjects.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sccrooks.Utility.ScriptableObjects.Events
{
    public class FloatEventListener : MonoBehaviour
    {
        [Tooltip("Event to reguster with.")]
        public FloatEvent Event;

        [Tooltip("Response to invoke when Event is raised.")]
        public MyFloatEvent Response;

        private void OnEnable()
        {
            Event.RegisterListener(this);
        }
        
        private void OnDisable()
        {
            Event.UnregisterListener(this);
        }

        public void OnEventRaised(float data)
        {
            Response.Invoke(data);
        }
    }
}
