using QFSW.QC;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class MainMenuController : MonoBehaviour
{
    SceneData _sceneData;

    /// <summary>
    /// Starts the game
    /// </summary>
    [Command]
    public void StartGame()
    {
        SceneManager.LoadScene(_sceneData.Game, LoadSceneMode.Single);
    }

    /// <summary>
    /// Exits the game
    /// </summary>
    [Command]
    public void ExitGame()
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
