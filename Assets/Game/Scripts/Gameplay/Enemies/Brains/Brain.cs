using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Gameplay.Enemies
{
    public abstract class Brain : ScriptableObject
    {
        public abstract void Think();
    }
}
