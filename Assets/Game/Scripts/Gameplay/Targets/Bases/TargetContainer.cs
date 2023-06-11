using MissileCommand.Infrastructure.ScriptableObjects;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Gameplay.Bases
{
    [CreateAssetMenu(fileName = "Target Container", menuName = "Gameplay/Target Container")]
    public class TargetContainer : ScriptableObject, ISerializationCallbackReceiver
    {
        public RuntimeCollection<GameObject> Targets;
        public RuntimeCollection<GameObject> ActiveTargets;
        public RuntimeCollection<GameObject> DeactivatedTargets;

        public void OnAfterDeserialize()
        {
            
        }

        public void OnBeforeSerialize()
        {

        }
    }
}