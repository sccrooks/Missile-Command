using UnityEngine;

namespace MissileCommand.Gameplay.Entities
{
    public class AILogicController : MonoBehaviour
    {
        [Header("AI Brain")]
        [SerializeField] public Brain AIBrain;

        [Header("Stats")]
        [Min(0), SerializeField] private float _speed;

        private void Start()
        {
            // Copy brain
            AIBrain = Instantiate(AIBrain);
        }

        // Update is called once per frame
        void Update()
        {
            AIBrain.Think(this);
        }

        /// <summary>
        /// Move towards specified Vector2 target
        /// </summary>
        /// <param name="target">Position to move towards</param>
        public void MoveTowardsTarget(Vector2 target)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, _speed * Time.deltaTime);
        }

        /// <summary>
        /// Destroys parent gameobject
        /// </summary>
        public void SelfDestruct()
        {
            Destroy(this.gameObject);
        }
    }
}