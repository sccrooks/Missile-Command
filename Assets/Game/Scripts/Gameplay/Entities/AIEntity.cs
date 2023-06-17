using Sccrooks.Utility.ScriptableObjects.Events;
using UnityEngine;

namespace MissileCommand.Gameplay.Entities
{
    public class AIEntity : Entity
    {
        [Header("Components")]
        [SerializeField] public AILogicController _aiLogicController;
        [SerializeField] private GameObject _explosionEffect;

        [Header("Events")]
        [SerializeField] private FloatEvent _aiEntityDestroyed;
        [SerializeField] private GameObjectEvent _entitySpawnRequestedEvent;

        [Header("Settings")]
        [SerializeField] private float _reward;
        [SerializeField] private bool _createExplosion;

        #region -- Onvalidate --
        public override void OnDestroy()
        {
            if (_createExplosion)
                Instantiate(_explosionEffect, this.gameObject.transform.position, Quaternion.identity);

            base.OnDestroy();
        }

        private void OnValidate()
        {
            _aiLogicController = this.gameObject.GetComponent<AILogicController>();
        }
        #endregion

        /// <summary>
        /// Basic Destruction. I.e no reward granted
        /// </summary>
        public override void Destroy()
        {
            base.Destroy();
        }

        /// <summary>
        /// Grant a reward when destroyed
        /// </summary>
        public void DestroyWithReward()
        {
            _aiEntityDestroyed.Raise(_reward);
            base.Destroy();
        }
    }
}
