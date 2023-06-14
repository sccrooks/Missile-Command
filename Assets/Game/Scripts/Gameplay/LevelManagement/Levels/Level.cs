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
        [SerializeField] private int _currentWave;

        [Header("Events")]
        [SerializeField] private GameEvent _levelStarted;
        [SerializeField] private GameEvent _levelEnded;

        public abstract void Start();
        public abstract void End();
        public abstract void Update();
    }
}