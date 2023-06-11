using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Gameplay.Bases
{
    [CreateAssetMenu(fileName = "Base Container", menuName = "Gameplay/Base Container")]
    public class BaseContainer : ScriptableObject
    {
        public List<Base> ActiveBases = new List<Base>();
        public List<Base> DestroyedBases = new List<Base>();


    }
}