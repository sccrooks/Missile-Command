using MissileCommand.Gameplay.LevelManagement;
using MissileCommand.Infrastructure.ScriptableObjects.Events;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace MissileCommand.Gameplay.LevelManagement
{
    [CreateAssetMenu(fileName = "Basic Wave", menuName = "Level Management/Basic Wave")]
    public class BasicWave : Wave
    {
        public override void Start()
        {
            _currentEntity = 0;
            _waveStarted?.Raise();
        }

        public override void End()
        {
            _waveEnded?.Raise();
        }

        public override void Update()
        {
            if (_currentEntity >= Entities.Count) return;
            SpawnEntity();
        }

        public override void SpawnEntity()
        {
            foreach(GameObject entity in Entities)
            {
                _spawnBuffer.Add(entity);
                _currentEntity++;
            }
        }

        
    }
}
