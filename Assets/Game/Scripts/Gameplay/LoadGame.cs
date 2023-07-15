using UnityEngine;
using UnityEngine.SceneManagement;

namespace MissileCommand.Gameplay
{
    public class LoadGame : MonoBehaviour
    {
        [SerializeField] private SceneData _sceneData;
        [SerializeField] private ScoreData _scoreData;
        [SerializeField] private string _saveDir;

        // Start is called before the first frame update
        void Start()
        {
            SceneManager.LoadScene(_sceneData.MainMenu, LoadSceneMode.Single);
        }
    }
}
