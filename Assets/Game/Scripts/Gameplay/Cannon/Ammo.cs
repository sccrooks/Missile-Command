using Sccrooks.Utility.ScriptableObjects.Events;
using Sccrooks.Utility.ScriptableObjects.Variables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Gameplay
{
    [CreateAssetMenu(fileName = "Ammo", menuName = "Data/Ammo")]
    public class Ammo : IntVariable
    {
        [SerializeField] private GameEvent _ammoModified;

        public override int RuntimeValue 
        { 
            get => base.RuntimeValue;
            set 
            { 
                base.RuntimeValue = value;
                _ammoModified?.Raise();
            } 
        }
    }
}
