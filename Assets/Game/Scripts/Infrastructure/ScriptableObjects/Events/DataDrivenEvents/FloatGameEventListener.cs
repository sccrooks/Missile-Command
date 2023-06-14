using MissileCommand.Infrastructure.ScriptableObjects.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Infrastructure.ScriptableObjects.Events
{
    public class FloatGameEventListener : MonoBehaviour
    {

        public FloatGameEvent Event;
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
