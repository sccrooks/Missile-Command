using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sccrooks.Utility.ScriptableObjects.Events
{
    public class IntEventListener : MonoBehaviour
    {
        [Tooltip("Event to register with.")]
        public IntEvent Event;

        [Tooltip("Response to invoke when Event is raised.")]
        public MyIntEvent Response;

        private void OnEnable()
        {
            Event.RegisterListener(this);
        }

        private void OnDisable()
        {
            Event.UnregisterListener(this);
        }

        public void OnEventRaised(int data)
        {
            Response.Invoke(data);
        }
    }
}
