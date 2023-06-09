using MissileCommand.Gameplay.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Gameplay.Enemies
{
    public class AIThinker : MonoBehaviour
    {
        [SerializeField] private Brain _brain;

        // Update is called once per frame
        void Update()
        {
            _brain.Think(this);
        }
    }
}