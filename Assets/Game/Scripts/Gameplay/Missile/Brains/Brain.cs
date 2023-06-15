using UnityEngine;

namespace MissileCommand.Gameplay.Enemies
{
    public abstract class Brain : ScriptableObject
    {
        public abstract void Think(AIThinker thinker);
        public abstract void FindTarget();
    }
}
