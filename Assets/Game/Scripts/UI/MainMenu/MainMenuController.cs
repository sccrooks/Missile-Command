using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using QFSW.QC;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private string _gameScene;

    /// <summary>
    /// Starts the game
    /// </summary>
    [Command]
    public void StartGame()
    {
        SceneManager.LoadScene(_gameScene, LoadSceneMode.Single);
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
}
