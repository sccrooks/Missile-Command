using Sccrooks.Utility.ScriptableObjects.Events;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Gameplay.LevelManagement
{
    public abstract class Wave : ScriptableObject
    {
        [Header("Entity list")]
        [SerializeField]
        protected List<GameObject> Entities = new List<GameObject>();

        [Header("Wave Data")]
        [SerializeField] protected int _currentEntity;

        [Header("Events")]
        [SerializeField] protected GameEvent _waveStarted;
        [SerializeField] protected GameEvent _waveEnded;
        [SerializeField] protected GameObjectEvent _spawnRequested;

        public abstract void Start();
        public abstract void End();
        public abstract void Update();
        public abstract void SpawnEntity();
    }
}  