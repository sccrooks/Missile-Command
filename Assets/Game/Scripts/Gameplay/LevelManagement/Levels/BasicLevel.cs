using Sccrooks.Utility.ScriptableObjects.Events;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Gameplay.LevelManagement
{
    [CreateAssetMenu(fileName = "Basic Level", menuName = "Level Management/Basic Level")]
    public class BasicLevel : ScriptableObject
    {
        [Header("Waves")]
        public List<Wave> Waves = new List<Wave>();

        [Header("Level Data")]
        [SerializeField] protected int _currentWave;
        [SerializeField] protected Color _primaryColour;
        [SerializeField] protected Color _secondaryColour;
        [SerializeField] protected Color _accentColour;

        [Header("Events")]
        [SerializeField] protected GameEvent _levelStarted;
        [SerializeField] protected GameEvent _levelEnded;
        [SerializeField] protected ColourEvent _primaryColourChanged;
        [SerializeField] protected ColourEvent _secondaryColourChanged;
        [SerializeField] protected ColourEvent _accentColourChanged;

        public void Start()
        {
            _currentWave = 0;
            _levelStarted.Raise();
            _primaryColourChanged.Raise(_primaryColour);
            _secondaryColourChanged.Raise(_secondaryColour);
            _accentColourChanged.Raise(_accentColour);
        }

        public void End()
        {
            _levelEnded.Raise();
        }

        public void Update()
        {
            if (_currentWave >= Waves.Count)
            {
                End();
                return;
            }

            Waves[_currentWave].Update();
        }

        public void OnWaveEnded()
        {
            _currentWave++; 
        }
    }
}