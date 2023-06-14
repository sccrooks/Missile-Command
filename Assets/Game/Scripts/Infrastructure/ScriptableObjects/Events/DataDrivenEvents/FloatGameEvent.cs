using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Infrastructure.ScriptableObjects.Events
{
    [CreateAssetMenu(fileName = "Float Event", menuName = "Infrastructure/Float event")]
    public class FloatGameEvent : ScriptableObject
    {
        private List<FloatGameEventListener> listeners = new List<FloatGameEventListener>();

        public void Raise(float data)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
                listeners[i].OnEventRaised(data);
        }

        public void RegisterListener(FloatGameEventListener listener)
        {
            listeners.Add(listener);
        }

        public void UnregisterListener(FloatGameEventListener listener)
        {
            listeners.Remove(listener);
        }
    }
}