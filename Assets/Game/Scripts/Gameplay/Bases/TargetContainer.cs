using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Gameplay.Bases
{
    [CreateAssetMenu(fileName = "Target Container", menuName = "Gameplay/Target Container")]
    public class TargetContainer : ScriptableObject
    {
        public List<GameObject> Targets = new List<GameObject>();
        public List<GameObject> ActiveTargets = new List<GameObject>();
        public List<GameObject> DestroyedTargets = new List<GameObject>();
    }
}