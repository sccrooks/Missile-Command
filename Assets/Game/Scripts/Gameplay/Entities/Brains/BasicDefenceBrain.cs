using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Gameplay.Entities
{
    public class BasicDefenceBrain : Brain
    {
        [SerializeField] private Vector2 _target;

        public override void FindTarget()
        {
            throw new System.NotImplementedException();
        }

        public override void Think(AILogicController thinker)
        {
            thinker.MoveTowardsTarget(_target);
        }
    }
}
