using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Gameplay.LevelManagement
{
    public class BasicLevelController : LevelController
    {
        public override void Start()
        {
            _currentLevel = 0;
        }

        public override void Update()
        {
            _levelList[_currentLevel].Update();
        }

        public override void OnlevelEnded()
        {
            _currentLevel++;
            if (_currentLevel >= _levelList.Count)
                _gameOverEvent.Raise();
        }

        public override void OnWaveEnded()
        {
            _levelList[_currentLevel].OnWaveEnded();
        }
    }
}