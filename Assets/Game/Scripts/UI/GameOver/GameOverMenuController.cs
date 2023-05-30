using QFSW.QC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MissileCommand.UI.GameOver
{
    public class GameOverMenuController : MonoBehaviour
    {
        [SerializeField] private SceneData _sceneData;

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