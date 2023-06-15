using System;
using UnityEngine;

namespace MissileCommand.Infrastructure.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Float Variable", menuName = "Infrastructure/Float Variable")]
    public class IntVariable : ScriptableObject, ISerializationCallbackReceiver
    {
        public int InitialValue;
        
        [NonSerialized]
        public int RunTimeValue;

        public void OnAfterDeserialize()
        {
            RunTimeValue = InitialValue;
        }

        public void OnBeforeSerialize()
        {

        }
    }
}