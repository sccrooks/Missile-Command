using Sccrooks.Utility.ScriptableObjects.Events;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Gameplay.LevelManagement
{
    [CreateAssetMenu(fileName = "Level", menuName = "Level Management/Level")]
    public class Level : ScriptableObject
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

        /// <summary>
        /// Called when wave is ended
        /// </summary>
        public void Start()
        {
            _currentWave = 0;
            Waves[_currentWave].Start();

            _levelStarted.Raise();
            _primaryColourChanged.Raise(_primaryColour);
            _secondaryColourChanged.Raise(_secondaryColour);
            _accentColourChanged.Raise(_accentColour);
        }

        /// <summary>
        /// Called when there are no waves left
        /// </summary>
        public void End()
        {
            _levelEnded.Raise();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Update()
        {
            if (_currentWave >= Waves.Count)
                End();
            else
                Waves[_currentWave].Update();
        }

        /// <summary>
        /// Attempt to start the next wave
        /// </summary>
        public void OnWaveEnded()
        {
            _currentWave++;
            Waves[_currentWave].Start();
        }
    }
}