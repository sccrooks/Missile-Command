using MissileCommand.Infrastructure;
using Sccrooks.Utility.ScriptableObjects.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Gameplay
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
        [SerializeField] private GameEvent _quitGameRequest;

        private void Start()
        {
            Debug.Log("Loading save data...");
            SaveData saveData = SaveDataManager.LoadGameData();
            if (saveData != null)
            {
                _highscoreData.Highscores = saveData.ScoreData;
            }
            Debug.Log("Loaded save data.");
        }

        private void OnDestroy()
        {
            Debug.Log("Saving save data...");
            SaveData saveData = new SaveData();
            saveData.ScoreData = _highscoreData.Highscores;
            SaveDataManager.SaveGameData(saveData);
            Debug.Log("Saved save data.");
        }
    }
}
