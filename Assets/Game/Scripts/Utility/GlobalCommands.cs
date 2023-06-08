using MissileCommand.Infrastructure.Events;
using QFSW.QC;
using UnityEngine;

namespace MissileCommand.Utils
{
    public class GlobalCommands : MonoBehaviour
    {
        public static GlobalCommands Instance { get; private set; }
        private void Start() => Instance = this;

        [Header("Events")]
        [SerializeField] private GameEvent _gameOverEvent;
        [SerializeField] private GameEvent _quitGameEvent;


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
            _quitGameEvent.Raise();

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
        }
    }
}