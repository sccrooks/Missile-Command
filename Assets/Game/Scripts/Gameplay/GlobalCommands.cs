using QFSW.QC;
using Sccrooks.Utility.ScriptableObjects.Events;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace MissileCommand.Gameplay
{
    public class GlobalCommands : MonoBehaviour
    {
        public static GlobalCommands Instance { get; private set; }
        private void Start() => Instance = this;

        [Header("Events")]
        [SerializeField] private GameEvent _gameOverEvent;
        [SerializeField] private GameEvent _quitGameEvent;
        [SerializeField] private IntEvent _increaseScoreEvent;
        [SerializeField] private GameEvent _endLevelEvent;
        [SerializeField] private GameEvent _endWaveEvent;


        [Command("End-Game")]
        public void EndGame()
        {
            _gameOverEvent.Raise();
        }

        /// <summary>
        /// Exits the game
        /// </summary>
        [Command("Quit")]
        public void QuitGame()
        {
            Debug.Log("Exiting Game...");

            _quitGameEvent.Raise();

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
        }

        [Command]
        public void IncreaseScore(int score)
        {
            Debug.Log($"Raising score by {score}.");
            _increaseScoreEvent.Raise(score);
        }

        [Command]
        public void EndLevel()
        {
            Debug.Log("Ending level.");
            _endLevelEvent.Raise();
        }

        [Command]
        public void EndWave()
        {
            Debug.Log("Ending wave.");
            _endWaveEvent.Raise();
        }
    }
}