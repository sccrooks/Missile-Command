namespace MissileCommand.Gameplay.LevelManagement
{
    /// <summary>
    /// Default level controller used for default game mode.
    /// This level controller runs through hand crafted levels
    /// Not to be confused with EndlessLevelController
    /// </summary>
    public class DefaultLevelController : LevelController
    {


        #region -- Start / Update --
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
        #endregion

        

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

        /// <summary>
        /// Requests the next level
        /// </summary>
        public void RequestNextLevel()
        {
            _nextLevelRequested = true;
        }

        #region -- Event Listeners --
        /// <summary>
        /// Event Listener for LevelEndedEvent
        /// </summary>
        public override void OnlevelEnded()
        {
            _nextLevelRequested = true;
        }

        /// <summary>
        /// Event listener for WaveEndedEvent
        /// </summary>
        public override void OnWaveEnded()
        {
            _levelList[_currentLevel].OnWaveEnded();
        }
        #endregion
    }
}