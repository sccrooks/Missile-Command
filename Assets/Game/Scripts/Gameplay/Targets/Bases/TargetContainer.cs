using MissileCommand.Infrastructure.ScriptableObjects;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Gameplay.Bases
{
    [CreateAssetMenu(fileName = "Target Container", menuName = "Gameplay/Target Container")]
    public class TargetContainer : ScriptableObject, ISerializationCallbackReceiver
    {
        public TargetCollection Targets;
        public TargetCollection ActiveTargets;
        public TargetCollection DeactivatedTargets;

        public void OnAfterDeserialize()
        {
            
        }

        public void OnBeforeSerialize()
        {

        }
    }
}