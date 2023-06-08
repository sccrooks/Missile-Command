using MissileCommand.Gameplay.Bases;
using MissileCommand.Gameplay.Reticle;
using MissileCommand.Infrastructure.Events;
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
        [SerializeField] private ILevelController _levelController;
        [SerializeField] private BaseHolder _baseHolder;

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
