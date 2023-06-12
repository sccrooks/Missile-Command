using MissileCommand.Infrastructure.ScriptableObjects.Events;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace MissileCommand.Gameplay.LevelManagement
{
    public abstract class Wave : ScriptableObject
    {
        [SerializeField]
        protected List<GameObject> Entities = new List<GameObject>();

        public abstract void StartWave(GameEvent waveStarted, GameEvent waveEnded, GameEvent entitySpawnRequested);
        public abstract void EndWave();
        public abstract void SpawnEntity();
    }
}  