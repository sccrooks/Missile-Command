using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sccrooks.Utility.ScriptableObjects.Events
{
    [CreateAssetMenu(fileName = "Float Event", menuName = "Infrastructure/Float event"), System.Serializable]
    public class FloatEvent : ScriptableObject
    {
        private List<FloatEventListener> listeners = new List<FloatEventListener>();

        public virtual void Raise(float data)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
                listeners[i].OnEventRaised(data);
        }

        public virtual void RegisterListener(FloatEventListener listener)
        {
            listeners.Add(listener);
        }

        public virtual void UnregisterListener(FloatEventListener listener)
        {
            listeners.Remove(listener);
        }
    }
}