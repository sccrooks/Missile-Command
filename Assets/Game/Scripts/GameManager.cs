using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour, IGameManager
{
    [SerializeField]
    private string _mainMenuScene;

    private void Start()
    {
        SceneManager.LoadScene(_mainMenuScene, LoadSceneMode.Single);
    }
}
