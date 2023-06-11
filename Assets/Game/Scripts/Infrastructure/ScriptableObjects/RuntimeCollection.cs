using MissileCommand.Infrastructure.ScriptableObjects.Events;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Infrastructure.ScriptableObjects
{
    public abstract class RuntimeCollection<T> : ScriptableObject
    {
        public List<T> Items = new List<T>();

        public GameEvent ItemAdded;
        public GameEvent ItemRemoved;

        public void Add (T item)
        {
            if (!Items.Contains(item))
            {
                Items.Add(item);
                ItemAdded?.Raise();
            }
        }

        public void Remove (T item)
        {
            if (Items.Contains(item))
            {
                Items.Remove(item);
                ItemRemoved?.Raise();
            }
        }

        public void Clear()
        {
            Items.Clear();
        }

        public int Count => Items.Count;

    }
}
