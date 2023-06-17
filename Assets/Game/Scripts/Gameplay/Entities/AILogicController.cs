using UnityEngine;

namespace MissileCommand.Gameplay.Entities
{
    public class AILogicController : MonoBehaviour
    {
        [Header("AI Brain")]
        [SerializeField] private Brain AIBrain;

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
    }
}