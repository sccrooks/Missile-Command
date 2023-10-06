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
    }
}
