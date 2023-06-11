using MissileCommand.Gameplay.Bases;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject.Asteroids;

namespace MissileCommand.Gameplay.Enemies
{
    [CreateAssetMenu(fileName = "Basic Brain", menuName = "Brains/Basic")]
    public class BasicBrain : Brain
    {
        public string _targetTag;
        public GameObject _target;

        public TargetContainer _targetContainer;

        public override void Think(AIThinker thinker)
        {
            if (_target == null)
            {
                int targetInt = Random.Range(0, _targetContainer.ActiveTargets.Count);
                _target = _targetContainer.ActiveTargets[targetInt];
            }

            Vector2 pos = new Vector2(_target.transform.position.x, _target.transform.position.y);
            thinker.GetComponent<Missile>().MoveTowardsTarget(pos);
        }
    }
}
