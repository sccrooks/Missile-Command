using System;
using UnityEngine;

namespace Sccrooks.Utility.ScriptableObjects.Variables
{
    [CreateAssetMenu(fileName = "Float Variable", menuName = "Infrastructure/Variables/Float Variable")]
    public class IntVariable : ScriptableObject, ISerializationCallbackReceiver
    {
        public int InitialValue;
        private int _runtimeVariable;

        public virtual int RuntimeValue
        {
            get { return _runtimeVariable; }
            set { _runtimeVariable = value; }
        }

        public void OnAfterDeserialize()
        {
            RuntimeValue = InitialValue;
        }

        public void OnBeforeSerialize()
        {
            // Do nothing
        }
    }
}