namespace MissileCommand.Gameplay.LevelManagement
{
    public class DefaultLevelController : LevelController
    {
        public override void Start()
        {
            _nextLevelRequested = true;
            _currentLevel = -1;
            ChangeLevel();
            _levelList[_currentLevel].Start();
        }

        public override void Update()
        {
            if (_nextLevelRequested)
                ChangeLevel();
            else
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

        public void ChangeLevel()
        {
            if (_activeEntities.Count > 0) return;
            else if (_currentLevel + 1 >= _levelList.Count)
            {
                _gameOverEvent.Raise();
                return;
            }
            else
            {
                _nextLevelRequested = false;
                _currentLevel++;
                _levelList[_currentLevel].Start();
            }
        }

        /// <summary>
        /// Force start the next level
        /// </summary>
        public void ForceNextLevel()
        {
            _nextLevelRequested = false;
            _currentLevel++;
            _levelList[_currentLevel].Start();
        }
    }
}