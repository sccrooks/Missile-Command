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
                if(!StartNextlevel())
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

        public bool StartNextlevel()
        {
            if (_activeEntities.Count > 0) return false;
            else
            {
                _currentLevel++;
                _nextLevelRequested = false;

                if (_currentLevel >= _levelList.Count)
                {
                    _gameOverEvent.Raise();
                }

                _levelList[_currentLevel].Start();
            }

            return true;
        }
    }
}