using Sccrooks.Utility.ScriptableObjects.Variables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Gameplay.Entities
{
    [CreateAssetMenu(fileName = "Basic Defense Brain", menuName = "Brains/Defense Basic Brain")]
    public class BasicDefenceBrain : Brain
    {
        [SerializeField] private GameObjectVariable _reticle;
        private Vector3 _target;
        private bool _foundTarget = false;

        public override void FindTarget()
        {
            _target = _reticle.RunTimeValue.gameObject.transform.position;
            _foundTarget = true;
        }

        public override void Think(AILogicController thinker)
        {
            if (!_foundTarget)
                FindTarget();

            thinker.MoveTowardsTarget(_target);

            if (Vector3.Distance(thinker.gameObject.transform.position, _target) <= 1)
                thinker.SelfDestruct();
        }
    }
}
