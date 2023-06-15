using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Infrastructure.ScriptableObjects.Events
{
    [CreateAssetMenu(fileName = "Float Event", menuName = "Infrastructure/Float event"), System.Serializable]
    public class FloatGameEvent : ScriptableObject
    {
        private List<FloatGameEventListener> listeners = new List<FloatGameEventListener>();

        public virtual void Raise(float data)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
                listeners[i].OnEventRaised(data);
        }

        public virtual void RegisterListener(FloatGameEventListener listener)
        {
            listeners.Add(listener);
        }

        public virtual void UnregisterListener(FloatGameEventListener listener)
        {
            listeners.Remove(listener);
        }
    }
}