using UnityEngine;

namespace MissileCommand.Gameplay.LevelManagement
{
    [CreateAssetMenu(fileName = "Basic Level", menuName = "Level Management/Basic Level")]
    public class BasicLevel : Level
    {
        public override void Start()
        {
            _currentWave = 0;
            _levelStarted.Raise();
            _primaryColourChanged.Raise(_primaryColour);
            _SecondaryColourChanged.Raise(_secondaryColour);
            _accentColourChanged.Raise(_accentColour);
        }

        public override void End()
        {
            _levelEnded.Raise();
        }

        public override void Update()
        {
            if (_currentWave >= Waves.Count)
            {
                End();
                return;
            }

            Waves[_currentWave].Update();
        }

        public override void OnWaveEnded()
        {
            _currentWave++; 
        }
    }
}