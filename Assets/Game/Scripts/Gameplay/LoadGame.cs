using UnityEngine;
using UnityEngine.SceneManagement;

namespace MissileCommand.Gameplay
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
