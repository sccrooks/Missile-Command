using Sccrooks.Utility.ScriptableObjects.Variables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Gameplay.Entities
{
    public class BasicDefenceBrain : Brain
    {
        [SerializeField] private Vector2 _target;
        [SerializeField] private GameObjectVariable _reticle;

        public override void FindTarget()
        {
            Vector3 reticlePosition = _reticle.RunTimeValue.gameObject.transform.position;
            _target = new Vector2(reticlePosition.x, reticlePosition.y);
        }

        public override void Think(AILogicController thinker)
        {
            if (_target == null)
                FindTarget();

            thinker.MoveTowardsTarget(_target);
        }
    }
}
