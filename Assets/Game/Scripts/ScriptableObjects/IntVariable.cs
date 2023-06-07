using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Infrastructure.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Float Variable", menuName = "Infrastructure/Float Variable")]
    public class IntVariable : ScriptableObject, ISerializationCallbackReceiver
    {
        public int InitialValue;
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