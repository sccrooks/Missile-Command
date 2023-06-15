using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sccrooks.Utility.ScriptableObjects.Events
{
    public class GameObjectGameEventListener : MonoBehaviour
    {
        [Tooltip("Event to reguster with.")]
        public GameObjectGameEvent Event;

        [Tooltip("Response to invoke when Event is raised.")]
        public GameObjectEvent Response;

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
            Debug.Log("Response invoked");
            Response.Invoke(data);
            Debug.Log("Response completed");
        }
    }
}