using MissileCommand.Gameplay.Targets;
using MissileCommand.Gameplay.Targets.Bases;
using MissileCommand.Infrastructure.ScriptableObjects;
using MissileCommand.Infrastructure.ScriptableObjects.Events;
using QFSW.QC;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MissileCommand.Gameplay.GameController
{
    public class GameController : MonoBehaviour
    {
        public static GameController Instance { get; private set; }

        [Header("Components")]
        [SerializeField] private SceneData _sceneData;
        [SerializeField] private Transform _spawnLocation;
        
        [Header("Stats/Settings")]
        [SerializeField] private float _score;
        [SerializeField] private bool _respawnBasesOnLevelEnd;

        [Header("Collections")]
        [SerializeField] private GameObjectCollection _entitySpawnCollection;
        [SerializeField] private GameObjectCollection _targetCollection;

        [Header("Events")]
        [SerializeField] private GameEvent _gameOverEvent;

        #region -- Awake/Start/OnDestroy --
        private void Awake()
        {
            Instance = this;
        }
        #endregion


        [Command("Instantiate-Entity")]
        public void InstaniateEntity()
        {
            Instantiate(_entitySpawnCollection.Items[0], _spawnLocation.transform.position, Quaternion.identity, _spawnLocation.transform);
            _entitySpawnCollection.Remove(_entitySpawnCollection.Items[0]);
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
            this._score += score;
        }
    }
}
