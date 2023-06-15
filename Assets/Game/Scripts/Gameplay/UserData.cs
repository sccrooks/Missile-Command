using Sccrooks.Utility.ScriptableObjects.Variables;
using UnityEngine;

namespace MissileCommand.Infrastructure.ScriptableObjects
{
    [CreateAssetMenu(fileName = "User Data", menuName = ("Infrastructure/User Data"))]
    public class UserData : ScriptableObject, ISerializationCallbackReceiver
    {
        public string Name;
        public IntVariable Score;

        public void OnAfterDeserialize()
        {
            // TODO: Save name to file
            //throw new System.NotImplementedException();
        }

        public void OnBeforeSerialize()
        {
            // TODO: Load name from file
            //throw new System.NotImplementedException();
        }
    }
}