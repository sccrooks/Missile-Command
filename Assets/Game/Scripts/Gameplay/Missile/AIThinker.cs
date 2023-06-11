using MissileCommand.Gameplay.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Gameplay.Enemies
{
    public class AIThinker : MonoBehaviour
    {
        public Brain Brain;

        // Update is called once per frame
        void Update()
        {
            Brain.Think(this);
        }
    }
}