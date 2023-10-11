using QFSW.QC;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MissileCommand.UI.MainMenu
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField]
        private SceneData _sceneData;

        [Header("Menus")]
        [SerializeField] private GameObject _mainMenu;
        [SerializeField] private GameObject _settingsMenu;

        private void Start()
        {
            OpenMainMenu();
        }

        /// <summary>
        /// Starts the game
        /// </summary>
        [Command("Start")]
        public void StartGame()
        {
            SceneManager.LoadScene(_sceneData.Game, LoadSceneMode.Single);
        }

        /// <summary>
        /// Starts the game in endless mode
        /// </summary>
        [Command("Start-Endless")]
        public void StartEndless()
        {
            SceneManager.LoadScene(_sceneData.Endless, LoadSceneMode.Single);
        }

        /// <summary>
        /// Opens the main menu
        /// </summary>
        [Command("Open-Main-Menu")]
        public void OpenMainMenu()
        {
            _levelEditor.SetActive(false);
            _settingsMenu.SetActive(false);

            _mainMenu.SetActive(true);
        }

        /// <summary>
        /// Opens the settings menu
        /// </summary>
        [Command("Open-Settings-Menu")]
        public void OpenSettings()
        {
            _mainMenu.SetActive(false);
            _levelEditor.SetActive(true);

            _settingsMenu.SetActive(true);
        }
    }
}