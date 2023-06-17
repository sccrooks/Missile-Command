using Sccrooks.Utility.ScriptableObjects.Events;
using UnityEngine;

namespace MissileCommand.Gameplay.Entities
{
    public class AIEntity : Entity
    {
        [Header("Components")]
        [SerializeField] public AILogicController _aiLogicController;

        [Header("Reward")]
        [SerializeField] private float _reward;

        [Header("Events")]
        [SerializeField] private FloatEvent _aiEntityDestroyed;

        #region -- Start / OnDestroy / Onvalidate --
        public override void Start()
        {
            base.Start();
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            _aiEntityDestroyed.Raise(_reward);
        }

        private void OnValidate()
        {
            _aiLogicController = this.gameObject.GetComponent<AILogicController>();
        }
        #endregion

        public override void Destroy()
        {
            base.Destroy();
        }

        public void BaseCollision()
        {
            Destroy();
        }

        public void EnvironmentCollision()
        {
            Destroy();
        }
    }
}
