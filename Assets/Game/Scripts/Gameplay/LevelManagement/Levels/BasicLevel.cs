using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Gameplay.LevelManagement
{
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
    }
}