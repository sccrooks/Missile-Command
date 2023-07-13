using MissileCommand.Gameplay;
using QFSW.QC;
using Sccrooks.Utility.ScriptableObjects.Variables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MissileCommand.UI.GameOver
{
    public class GameOverMenuController : MonoBehaviour
    {
        [Header("Menus")]
        [SerializeField] private GameObject _gameOverMenu;
        [SerializeField] private GameObject _newHighscoreMenu;
        [SerializeField] private GameObject _addHighscoreMenu;

        [Header("Components")]
        [SerializeField] private InputField _nameInputField;

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
                DisplayNewHighscoreMenu();
            else
                DisplayGameOverMenu();
        }

        #region - Game over menu -
        /// <summary>
        /// Display game over menu
        /// </summary>
        public void DisplayGameOverMenu()
        {
            _newHighscoreMenu.SetActive(false);
            _addHighscoreMenu.SetActive(false);

            _gameOverMenu.SetActive(true);
        }
        #endregion

        #region - New highscore menu -
        public void DisplayNewHighscoreMenu()
        {
            _gameOverMenu.SetActive(false);
            _addHighscoreMenu.SetActive(false);

            _newHighscoreMenu.SetActive(true);
        }

        
        public void DisplayAddHighscoreMenu()
        {
            _addHighscoreMenu.SetActive(true);
        }

        public void SaveHighscore()
        {

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