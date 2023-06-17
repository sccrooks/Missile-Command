using Sccrooks.Utility.ScriptableObjects.Variables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Gameplay.Entities
{
    [CreateAssetMenu(fileName = "Basic Brain", menuName = "Brains/Defense Basic Brain")]
    public class BasicDefenceBrain : Brain
    {
        [SerializeField] private GameObjectVariable _reticle;
        private Vector2 _target;
        private bool _foundTarget = false;

        public override void FindTarget()
        {
            Vector3 reticlePosition = _reticle.RunTimeValue.gameObject.transform.position;
            _target = new Vector2(reticlePosition.x, reticlePosition.y);
            _foundTarget = true;
        }

        public override void Think(AILogicController thinker)
        {
            if (!_foundTarget)
                FindTarget();

            thinker.MoveTowardsTarget(_target);
        }
    }
}
