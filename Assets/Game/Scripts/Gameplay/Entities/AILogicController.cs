using UnityEngine;

namespace MissileCommand.Gameplay.Enemies
{
    public class AILogicController : MonoBehaviour
    {
        [Header("AI Brain")]
        [SerializeField] private Brain AIBrain;
        [HideInInspector] public Brain Brain;

        private void Start()
        {
            // Copy brain
            Brain = Instantiate(AIBrain);
        }

        // Update is called once per frame
        void Update()
        {
            Brain.Think(this);
        }
    }
}