using QFSW.QC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Gameplay.Bases {
    public class BaseHolder : MonoBehaviour
    {
        [SerializeField]
        private List<Base> _baseList = new List<Base>();

        [Command("Bases-DestroyBase")]
        public void DestroyBase(int i)
        {
            if (i < 0 || i >= _baseList.Count)
            {
                Debug.LogWarning("Cannot destroy base at index, index is out of range");
                return;
            }

            _baseList[i].Destroy();
        }
    }
}
