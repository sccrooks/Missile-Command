using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Infrastructure.ScriptableObjects.Events
{
    public class GameObjectGameEventListener : MonoBehaviour
    {
        public GameObjectGameEvent Event;
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