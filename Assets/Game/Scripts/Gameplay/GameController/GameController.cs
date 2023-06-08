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
        [SerializeField] private ReticleController _reticle;

        [Header("Game stats")]
        [SerializeField] private int score;
        [SerializeField] private float speed;

        [Header("Events")]
        [SerializeField] private GameEvent _gameOverEvent;

        #region -- Awake/Start/OnDestroy --
        private void Awake()
        {
            Instance = this;
        }
        #endregion

        /// <summary>
        /// Move the reticle based on movement vector
        /// </summary>
        /// <param name="movement">Vector2</param>
        public void MoveReticle(Vector2 movement)
        {
            _reticle.Transform.position += new Vector3(movement.x * speed * Time.deltaTime, movement.y * speed * Time.deltaTime, 0);
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
