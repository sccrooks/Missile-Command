using QFSW.QC;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;


public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private SceneData _sceneData;

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
    /// Exits the game
    /// </summary>
    [Command("Quit")]
    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    [Command]
    public void GameOver()
    {
        throw new System.NotImplementedException();
    }
}
