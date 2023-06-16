using Sccrooks.Utility.ScriptableObjects.Events;
using Sccrooks.Utility.ScriptableObjects.RuntimeCollections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Gameplay.LevelManagement
{
    public abstract class LevelController : MonoBehaviour
    {
        [Header("Levels")]
        [SerializeField] protected List<BasicLevel> _levelList = new List<BasicLevel>();

        [Header("Components")]
        [SerializeField] protected GameObjectCollection _activeEntities;

        [Header("Level Controller Data")]
        [SerializeField] protected int _currentLevel;
        [SerializeField] protected bool _nextLevelRequested;

        [Header("Events")]
        [SerializeField] protected GameEvent _gameOverEvent;

        public abstract void Start();
        public abstract void Update();
        public abstract void OnlevelEnded();
        public abstract void OnWaveEnded();
    }
}