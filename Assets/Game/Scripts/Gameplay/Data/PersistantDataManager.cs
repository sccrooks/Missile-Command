using Sccrooks.Utility.ScriptableObjects.Events;
using UnityEngine;

namespace MissileCommand.Gameplay.Data
{
    public class PersistantDataManager : MonoBehaviour
    {
        public static PersistantDataManager Instance 
        { 
            get { return Instance; }
            private set 
            {
                if (Instance == null)
                    Instance = value;
                else
                    Debug.LogWarning("An Instance of PersistantDataManager " +
                        "already exists!");
            }
        }

        [SerializeField] private HighscoreData _highscoreData;
        [SerializeField] private GameEvent _gameLoadedEvent;
        [SerializeField] private GameEvent _gameSavedEvent;

        private void Awake()
        {
            LoadGameData();
        }

        private void OnDestroy()
        {
            SaveGameData();
        }

        public void LoadGameData()
        {
            Debug.Log("Loading save data...");
            SaveData saveData = SaveDataManager.LoadGameData();
            if (saveData != null)
            {
                _highscoreData.Highscores = saveData.HighscoreData;
            }

            Debug.Log("Loaded save data.");
            _gameLoadedEvent.Raise();
        }

        public void SaveGameData()
        {
            Debug.Log("Saving save data...");
            SaveData saveData = new SaveData();
            saveData.HighscoreData = _highscoreData.Highscores;
            SaveDataManager.SaveGameData(saveData);

            Debug.Log("Saved save data.");
            _gameSavedEvent.Raise();
        }
    }
}
