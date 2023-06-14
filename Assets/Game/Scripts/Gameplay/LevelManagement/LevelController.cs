using MissileCommand.Infrastructure.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Gameplay.LevelManagement
{
    public abstract class LevelController : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private GameObjectCollection _entitySpawnList;

        public abstract void Start();
        public abstract void Update();
    }
}