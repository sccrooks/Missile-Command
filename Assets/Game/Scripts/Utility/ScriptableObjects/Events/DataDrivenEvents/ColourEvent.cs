using System.Collections.Generic;
using UnityEngine;

namespace Sccrooks.Utility.ScriptableObjects.Events
{
    [CreateAssetMenu(fileName = "Color Event", menuName = "Infrastructure/Events/Color event")]
    public class ColourEvent : ScriptableObject
    {
        private List<ColourEventListener> listeners = new List<ColourEventListener>();

        public void Raise(Color data)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
                listeners[i].OnEventRaised(data);
        }

        public void RegisterListener(ColourEventListener listener)
        {
            listeners.Add(listener);
        }

        public void UnregisterListener(ColourEventListener listener)
        {
            listeners.Remove(listener);
        }
    }
}
