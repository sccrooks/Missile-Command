using MissileCommand.Gameplay.LevelManagement;
using MissileCommand.Infrastructure.ScriptableObjects.Events;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace MissileCommand.Gameplay.LevelManagement
{
    [CreateAssetMenu(fileName = "Basic Wave", menuName = "Gameplay/LevelManagement/BasicWave")]
    public class BasicWave : Wave
    {
        [SerializeField] private int _spawnDelay = 0;
        [SerializeField] private int _spawnedEntites = 0;

        [Header("Events")]
        [SerializeField] private GameEvent _waveStarted;
        [SerializeField] private GameEvent _waveEnded;
        [SerializeField] private GameEvent _entitySpawnRequested;

        public override void StartWave(GameEvent waveStarted, GameEvent waveEnded, GameEvent entitySpawnRequested)
        {
            // Get events
            _waveStarted = waveStarted;
            _waveEnded = waveEnded;
            _entitySpawnRequested = entitySpawnRequested;

            _spawnedEntites = 0;
            _waveStarted?.Raise();
            SpawnEntity();
        }

        public override void EndWave()
        {
            _waveEnded?.Raise();
        }

        public override async void SpawnEntity()
        {
            if (_spawnedEntites <= Entities.Count) return;
            _spawnedEntites++;

            await Task.Delay(_spawnDelay);
            _entitySpawnRequested?.Raise();
        }
    }
}
