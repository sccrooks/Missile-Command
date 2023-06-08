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


        [Command("End Game")]
        public void EndGame()
        {
            _gameOverEvent.Raise();
        }
    }
}