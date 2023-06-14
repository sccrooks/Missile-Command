using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Gameplay.LevelManagement
{
    public class DefaultLevelController : LevelController
    {
        public override void Start()
        {
            _nextLevelRequested = false;
            _currentLevel = 0;
        }

        public override void Update()
        {
            if (_nextLevelRequested)
            {
                if (_activeEntities.Count > 0) return;
                else
                {
                    _currentLevel++;
                    _nextLevelRequested = false;

                    if (_currentLevel >= _levelList.Count)
                        _gameOverEvent.Raise();
                }

                return;
            }
                
            _levelList[_currentLevel].Update();
        }

        public override void OnlevelEnded()
        {
            _nextLevelRequested = true;
            
        }

        public override void OnWaveEnded()
        {
            _levelList[_currentLevel].OnWaveEnded();
        }
    }
}