using MissileCommand.Gameplay.Targets;
using QFSW.QC;
using Sccrooks.Utility.ScriptableObjects.Events;
using Sccrooks.Utility.ScriptableObjects.RuntimeCollections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

namespace MissileCommand.Gameplay.GameController
{
    public class GameController : MonoBehaviour
    {
        public static GameController Instance { get; private set; }

        [Header("Components")]
        [SerializeField] private SceneData _sceneData;
        [SerializeField] private Transform _spawnLocation;
        
        [Header("Stats/Settings")]
        [SerializeField] private int _score;
        [SerializeField] private bool _respawnBasesOnLevelEnd;

        [Header("Collections")]
        [SerializeField] private GameObjectCollection _targetCollection;
        [SerializeField] private GameObjectCollection _activeTargetCollection;

        [Header("Events")]
        [SerializeField] private GameEvent _gameOverEvent;
        [SerializeField] private GameEvent _allTargetsDestroyedEvent;
        [SerializeField] private IntEvent _scoreUpdatedEvent;

        #region -- Awake/Start/OnDestroy --
        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            _score = 0;
            _scoreUpdatedEvent.Raise(_score);
        }
        #endregion

        /// <summary>
        /// Called when target is destroyed, if there
        /// are no remaining targets we end game
        /// </summary>
        public void OnActiveTargetDestroyed()
        {
            if (_activeTargetCollection.Count <= 0)
            {
                _allTargetsDestroyedEvent.Raise();
            }
        }

        /// <summary>
        /// Event listener for BaseHolder.AllBasesDestroyed.
        /// We want to attempt to end game once this event has triggered
        /// </summary>
        public void OnAllBasesDestroyed()
        {
            _gameOverEvent.Raise();
        }

        public void OnLevelEnded()
        {
            if(_respawnBasesOnLevelEnd)
            {
                foreach (GameObject item in _targetCollection.Items)
                {
                    item.GetComponent<Target>().SetActive(true);
                }
            }
        }

        /// <summary>
        /// Attempts to end the game
        /// </summary>
        [Command]
        public void EndGame()
        {
            SceneManager.LoadScene(_sceneData.GameOver);
        }

        public void IncreaseScore(float score)
        {
            this._score += (int)score;
            _scoreUpdatedEvent.Raise(this._score);
        }
    }
}
