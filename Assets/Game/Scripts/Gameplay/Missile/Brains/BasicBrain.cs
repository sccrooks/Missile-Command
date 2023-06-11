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
        public Base _target;

        public override void Think(AIThinker thinker)
        {
            if (_target == null || !_target.IsActive)
            {
                // Find a new target
                GameObject[] targets = GameObject.FindGameObjectsWithTag(_targetTag);
                List<Base> potentialTargets = new List<Base>();


                foreach (GameObject target in targets)
                {
                    Base @base = target.GetComponent<Base>();
                    if (@base != null && @base.IsActive)
                        potentialTargets.Add(@base);
                }


                int targetInt = Random.Range(0, potentialTargets.Count);
                Debug.Log(targetInt);

                _target = potentialTargets[targetInt];
            }

            Vector2 pos = new Vector2(_target.transform.position.x, _target.transform.position.y);
            thinker.GetComponent<Missile>().MoveTowardsTarget(pos);
        }
    }
}
