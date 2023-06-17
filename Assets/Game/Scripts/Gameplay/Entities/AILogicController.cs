using UnityEngine;

namespace MissileCommand.Gameplay.Entities
{
    public class AILogicController : MonoBehaviour
    {
        [Header("AI Brain")]
        [SerializeField] private Brain AIBrain;

        [Header("Stats")]
        [SerializeField] private float _speed;

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

        public void MoveTowardsTarget(Vector2 target)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, _speed * Time.deltaTime);
        }
    }
}