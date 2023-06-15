using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace sccrooks.Infrastructure
{
    public class LoadGame : MonoBehaviour
    {
        [SerializeField] private SceneData _sceneData;

        // Start is called before the first frame update
        void Start()
        {
            SceneManager.LoadScene(_sceneData.MainMenu, LoadSceneMode.Single);
        }
    }
}
