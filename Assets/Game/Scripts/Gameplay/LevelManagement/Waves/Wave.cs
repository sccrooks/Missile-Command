using MissileCommand.Gameplay.Entities;
using Sccrooks.Utility.ScriptableObjects.Events;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Gameplay.LevelManagement
{
    public class Wave : ScriptableObject
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

        /// <summary>
        /// Resets wave stats, called on wave start
        /// </summary>
        public virtual void Start()
        {
            _currentEntity = 0;
            _waveStarted?.Raise();
        }
        
        /// <summary>
        /// Called on wave end, raises _waveEnded event
        /// </summary>
        public virtual void End()
        {
            _waveEnded?.Raise();
        }

        /// <summary>
        /// Called every frame, controls wave logic
        /// </summary>
        public virtual void Update()
        {
            if (_currentEntity >= Entities.Count)
            {
                End();
                return;
            }
        }

        /// <summary>
        /// Spawns a wave entity.
        /// By default will spawn the current entity specified in _currentEntity
        /// </summary>
        public virtual void SpawnEntity()
        {
            _spawnRequested.Raise(Entities[_currentEntity]);
        }
    }
}  