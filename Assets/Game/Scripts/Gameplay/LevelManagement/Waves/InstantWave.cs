using UnityEngine;

namespace MissileCommand.Gameplay.LevelManagement
{
    [CreateAssetMenu(fileName = "Basic Wave", menuName = "Level Management/Basic Wave")]
    public class InstantWave : Wave
    {
        public override void Start() => base.Start();

        public override void End() => base.End();

        public override void Update()
        {
            base.Update();
            SpawnEntity();
        }

        public override void SpawnEntity()
        {
            foreach(GameObject entity in Entities)
            {
                _spawnRequested.Raise(entity);
                _currentEntity++;
            }
        }
    }
}
