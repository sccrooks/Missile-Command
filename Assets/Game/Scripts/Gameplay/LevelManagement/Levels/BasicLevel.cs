using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Gameplay.LevelManagement
{
    [CreateAssetMenu(fileName = "Basic Level", menuName = "Level Management/Basic Level")]
    public class BasicLevel : Level
    {
        public override void Start()
        {
            _currentWave = 0;
            _levelStarted.Raise();
        }

        public override void End()
        {
            _levelEnded.Raise();
        }

        public override void Update()
        {
            
        }

        public override void OnWaveEnded()
        {
            _currentWave++;
            if (_currentWave >= Waves.Count)
                End();
        }
    }
}