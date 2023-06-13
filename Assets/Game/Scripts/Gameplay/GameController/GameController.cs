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
        [SerializeField] private GameObjectCollection _entitySpawnCollection;

        [Header("Game stats")]
        [SerializeField] private int score;

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
            Debug.Log("Spawning entity");
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

        /// <summary>
        /// Attempts to end the game
        /// </summary>
        [Command]
        public void EndGame()
        {
            SceneManager.LoadScene(_sceneData.GameOver);
        }
    }
}
