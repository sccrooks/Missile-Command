using Sccrooks.Utility.ScriptableObjects.Events;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Gameplay.LevelManagement
{
    public abstract class Level : ScriptableObject
    {
        [Header("Waves")]
        public List<Wave> Waves = new List<Wave>();

        [Header("Level Data")]
        [SerializeField] protected int _currentWave;
        [SerializeField] protected Color _primaryColour;
        [SerializeField] protected Color _secondaryColour;
        [SerializeField] protected Color _accentColour;

        [Header("Events")]
        [SerializeField] protected GameEvent _levelStarted;
        [SerializeField] protected GameEvent _levelEnded;

        public abstract void Start();
        public abstract void End();
        public abstract void Update();
        public abstract void OnWaveEnded();
    }
}