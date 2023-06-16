using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sccrooks.Utility.ScriptableObjects.Events
{
    [CreateAssetMenu(fileName = "GameObject Event", menuName = "Infrastructure/Events/GameObject event")]
    public class GameObjectEvent : ScriptableObject
    {
        private List<GameObjectEventListener> listeners = new List<GameObjectEventListener>();

        public void Raise(GameObject data)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
                listeners[i].OnEventRaised(data);
        }

        public void RegisterListener(GameObjectEventListener listener)
        {
            listeners.Add(listener);
        }

        public void UnregisterListener(GameObjectEventListener listener)
        {
            listeners.Remove(listener);
        }
    }
}