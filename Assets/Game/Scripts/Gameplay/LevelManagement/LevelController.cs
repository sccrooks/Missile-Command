using MissileCommand.Infrastructure.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Gameplay.LevelManagement
{
    public abstract class LevelController : MonoBehaviour
    {
        [Header("Levels")]
        [SerializeField] protected List<Level> _levelList = new List<Level>();

        [Header("Components")]
        [SerializeField] protected GameObjectCollection _entitySpawnList;

        [Header("Level Controller Data")]
        [SerializeField] protected int _currentLevel;

        public abstract void Start();
        public abstract void Update();
        public abstract void OnlevelEnded();
        public abstract void OnWaveEnded();
    }
}