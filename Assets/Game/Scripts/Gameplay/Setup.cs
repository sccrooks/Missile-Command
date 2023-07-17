using UnityEngine;
using UnityEngine.SceneManagement;
using MissileCommand.Infrastructure;

namespace MissileCommand.Gameplay
{
    public class Setup : MonoBehaviour
    {
        [SerializeField] private SceneData _sceneData;
        [SerializeField] private ScoreData _scoreData;

        // Start is called before the first frame update
        void Start()
        {
            LoadData();
            SceneManager.LoadScene(_sceneData.MainMenu, LoadSceneMode.Single);
        }

        private void LoadData()
        {
            Debug.Log("Loading save data...");
            SaveData saveData = SaveDataManager.LoadGameData();
            if (saveData != null)
            {
                _scoreData.Highscores = saveData.ScoreData.Highscores;
            }
        }
    }
}
