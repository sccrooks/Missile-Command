using UnityEngine;
using UnityEngine.SceneManagement;
using MissileCommand.Infrastructure;
using System.Collections.Generic;
using Mono.CSharp;

namespace MissileCommand.Gameplay
{
    public class Setup : MonoBehaviour
    {
        [SerializeField] private SceneData _sceneData;
        

        // Start is called before the first frame update
        void Start()
        {
            SceneManager.LoadScene(_sceneData.MainMenu, LoadSceneMode.Single);
        }
    }
}
