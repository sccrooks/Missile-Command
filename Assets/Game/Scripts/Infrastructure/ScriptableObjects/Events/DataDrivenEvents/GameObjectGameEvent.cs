using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Infrastructure.ScriptableObjects.Events
{
    [CreateAssetMenu(fileName = "GameObject Event", menuName = "Infrastructure/GameObject event")]
    public class GameObjectGameEvent : ScriptableObject
    {
        private List<GameObjectGameEventListener> listeners = new List<GameObjectGameEventListener>();

        public void Raise(GameObject data)
        {
            Debug.Log("Event raised");
            for (int i = listeners.Count - 1; i >= 0; i--)
                listeners[i].OnEventRaised(data);
            Debug.Log("Event Finished");
        }

        public void RegisterListener(GameObjectGameEventListener listener)
        {
            listeners.Add(listener);
        }

        public void UnregisterListener(GameObjectGameEventListener listener)
        {
            listeners.Remove(listener);
        }
    }
}