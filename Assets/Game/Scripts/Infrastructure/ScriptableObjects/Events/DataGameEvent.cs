using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Infrastructure.ScriptableObjects.Events
{
    public class DataGameEvent<T> : MonoBehaviour
    {
        private List<DataGameEventListener<T>> listeners = new List<DataGameEventListener<T>>();

        public void Raise(T data)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
                listeners[i].OnEventRaised(data);
        }

        public void RegisterListener(DataGameEventListener<T> listener)
        {
            listeners.Add(listener);
        }

        public void UnregisterListener(DataGameEventListener<T> listener)
        {
            listeners.Remove(listener);
        }
    }
}
