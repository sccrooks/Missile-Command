using MissileCommand.Gameplay;
using QFSW.QC;
using Sccrooks.Utility.ScriptableObjects.Variables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MissileCommand.UI.GameOver
{
    public class GameOverMenuController : MonoBehaviour
    {
        [Header("Menus")]
        [SerializeField] private GameObject _newHighscoreMenu;
        [SerializeField] private GameObject _gameOverMenu;

        [Header("Data")]
        [SerializeField] private SceneData _sceneData;
        [SerializeField] private ScoreData _highscores;
        [SerializeField] private IntVariable _score;

        private bool _newHighscore = false;

        private void Start()
        {
            _newHighscore = false;

            foreach (Score score in _highscores._highscores)
            {
                if (_score.RunTimeValue > score.Value)
                {
                    _newHighscore = true;
                }
            }

            if (_newHighscore)
                _newHighscoreMenu.SetActive(true);
            else
                _gameOverMenu.SetActive(true);
        }

        /// <summary>
        /// Restarts the game
        /// </summary>
        [Command("Play-Again")]
        public void PlayAgain()
        {
            SceneManager.LoadScene(_sceneData.Game, LoadSceneMode.Single);
        }

        /// <summary>
        /// Returns to main menu
        /// </summary>
        [Command("MainMenu")]
        public void MainMenu()
        {
            SceneManager.LoadScene(_sceneData.MainMenu, LoadSceneMode.Single);
        }
    }
}