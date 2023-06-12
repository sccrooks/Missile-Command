using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Gameplay.LevelManagement
{
    public abstract class Wave : ScriptableObject
    {
        public List<GameObject> missiles = new List<GameObject>();

        public abstract void SpawnMissiles();
    }
}  