using MissileCommand.Gameplay;
using QFSW.QC;
using Sccrooks.Utility.ScriptableObjects.Variables;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
        [SerializeField] private GameObject _saveHighscoreMenu;

        [Header("Components")]
        [SerializeField] private TMP_InputField _nameInputField;

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
            _saveHighscoreMenu.SetActive(false);

            _gameOverMenu.SetActive(true);
        }
        #endregion

        #region - New highscore menu -
        public void DisplayNewHighscoreMenu()
        {
            _gameOverMenu.SetActive(false);
            _saveHighscoreMenu.SetActive(false);

            _newHighscoreMenu.SetActive(true);
        }
        #endregion

        #region Save Highscore menu
        /// <summary>
        /// Displays save highscore menu
        /// </summary>
        public void DisplaySaveHighscoreMenu()
        {
            _gameOverMenu.SetActive(false);
            _newHighscoreMenu.SetActive(false);

            _saveHighscoreMenu.SetActive(true);
        }

        /// <summary>
        /// Attempts to save a highscore
        /// </summary>
        public void SaveHighscore()
        {
            string name = _nameInputField.text.Trim();

            if (name.Length == 0)
                return;
            else
                return;
        }
        #endregion

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