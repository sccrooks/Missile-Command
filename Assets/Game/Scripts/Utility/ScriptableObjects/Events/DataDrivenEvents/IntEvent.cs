using System.Collections.Generic;
using UnityEngine;

namespace Sccrooks.Utility.ScriptableObjects.Events
{
    [CreateAssetMenu(fileName = "Int Event", menuName = "Infrastructure/Events/Int event")]
    public class IntEvent : ScriptableObject
    {
        private List<IntEventListener> listeners = new List<IntEventListener>();

        public void Raise(int data)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
                listeners[i].OnEventRaised(data);
        }

        public void RegisterListener(IntEventListener listener)
        {
            listeners.Add(listener);
        }

        public void UnregisterListener(IntEventListener listener)
        {
            listeners.Remove(listener);
        }
    }
}
