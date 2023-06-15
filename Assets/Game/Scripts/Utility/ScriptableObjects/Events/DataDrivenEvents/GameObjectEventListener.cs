using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sccrooks.Utility.ScriptableObjects.Events
{
    public class GameObjectEventListener : MonoBehaviour
    {
        [Tooltip("Event to reguster with.")]
        public GameObjectEvent Event;

        [Tooltip("Response to invoke when Event is raised.")]
        public MyGameObjectEvent Response;

        private void OnEnable()
        {
            Event.RegisterListener(this);
        }

        private void OnDisable()
        {
            Event.UnregisterListener(this);
        }

        public void OnEventRaised(GameObject data)
        {
            Response.Invoke(data);
        }
    }
}