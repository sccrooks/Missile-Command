using UnityEngine;

namespace MissileCommand.Gameplay.Entities
{
    public abstract class Brain : ScriptableObject
    {
        public abstract void Think(AILogicController thinker);
        public abstract void FindTarget();
    }
}
