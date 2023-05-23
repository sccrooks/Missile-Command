using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private string _gameScene;

    /// <summary>
    /// Starts the game
    /// </summary>
    public void StartGame()
    {
        SceneManager.LoadScene(_gameScene, LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else 
            Application.Quit();
        #endif
    
    }
}
