using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData : ScriptableObject, ISerializationCallbackReceiver
{
    public string Name;

    public void OnAfterDeserialize()
    {
        // TODO: Save name to file
        throw new System.NotImplementedException();
    }

    public void OnBeforeSerialize()
    {
        // TODO: Load name from file
        throw new System.NotImplementedException();
    }
}
