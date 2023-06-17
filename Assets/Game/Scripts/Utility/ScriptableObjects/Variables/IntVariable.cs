using System;
using UnityEngine;

namespace Sccrooks.Utility.ScriptableObjects.Variables
{
    [CreateAssetMenu(fileName = "Float Variable", menuName = "Infrastructure/Variables/Float Variable")]
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