using MissileCommand.Infrastructure.ScriptableObjects;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Gameplay.Targets
{
    [CreateAssetMenu(fileName = "Target Container", menuName = "Gameplay/Target Container")]
    public class TargetContainer : ScriptableObject, ISerializationCallbackReceiver
    {
        public GameObjectCollection Targets;
        public GameObjectCollection ActiveTargets;
        public GameObjectCollection DeactivatedTargets;

        public void OnAfterDeserialize()
        {
            
        }

        public void OnBeforeSerialize()
        {

        }
    }
}