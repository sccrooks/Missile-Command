using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Gameplay
{
    public class PersistantDataManager : MonoBehaviour
    {
        public static PersistantDataManager Instance 
        { 
            get { return Instance; }
            private set 
            {
                if (Instance == null)
                    Instance = value;
                else
                    Debug.LogWarning("An Instance of PersistantDataManager " +
                        "already exists!");
            }
        }
    }
}
