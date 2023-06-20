using Sccrooks.Utility.ScriptableObjects.Events;
using Sccrooks.Utility.ScriptableObjects.RuntimeCollections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Gameplay.LevelManagement
{
    /// <summary>
    /// Default level controller used for default game mode.
    /// This level controller runs through hand crafted levels
    /// Not to be confused with EndlessLevelController
    /// </summary>
    public class LevelController : MonoBehaviour
    {
        [Header("Levels")]
        [SerializeField] private List<BasicLevel> _levelList = new List<BasicLevel>();

        [Header("Components")]
        [SerializeField] private GameObjectCollection _activeEntities;

        [Header("Level Controller Data")]
        [SerializeField] private int _currentLevel;
        [SerializeField] private bool _nextLevelRequested;

        [Header("Events")]
        [SerializeField] private GameEvent _gameOverEvent;

        #region -- Start / Update --
        public void Start()
        {
            // Set the controller to the first level
            _currentLevel = 0;
            _levelList[_currentLevel].Start();
        }

        public void Update()
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
        public void OnlevelEnded()
        {
            _nextLevelRequested = true;
        }

        /// <summary>
        /// Event listener for WaveEndedEvent
        /// </summary>
        public void OnWaveEnded()
        {
            _levelList[_currentLevel].OnWaveEnded();
        }
        #endregion
    }
}