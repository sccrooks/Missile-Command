using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sccrooks.Utility.ScriptableObjects.Variables
{
    [CreateAssetMenu(fileName = "GameObject Variable", menuName = "Infrastructure/Variables/GameObject Variable")]
    public class GameObjectVariable : ScriptableObject, ISerializationCallbackReceiver
    {
        public GameObject InitialValue;

        [NonSerialized]
        public GameObject RunTimeValue;

        public void OnAfterDeserialize()
        {
            RunTimeValue = InitialValue;
        }

        public void OnBeforeSerialize()
        {

        }
    }
}
