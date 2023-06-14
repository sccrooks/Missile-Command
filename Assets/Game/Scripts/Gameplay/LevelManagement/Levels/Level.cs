using MissileCommand.Infrastructure.ScriptableObjects.Events;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace MissileCommand.Gameplay.LevelManagement
{
    public abstract class Level : ScriptableObject
    {
        [Header("Waves")]
        public List<Wave> Waves = new List<Wave>();

        [Header("Level Data")]
        [SerializeField] protected int _currentWave;

        [Header("Events")]
        [SerializeField] protected GameEvent _levelStarted;
        [SerializeField] protected GameEvent _levelEnded;

        public abstract void Start();
        public abstract void End();
        public abstract void Update();
    }
}