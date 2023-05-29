using QFSW.QC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Gameplay.Bases {
    public class BaseHolder : MonoBehaviour
    {
        [SerializeField]
        private List<Base> _baseList = new List<Base>();

        /// <summary>
        /// Destroy a base at index
        /// </summary>
        /// <param name="i">Index of base to destroy</param>
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

        /// <summary>
        /// Revive a base at index
        /// </summary>
        /// <param name="i">Index of base to revive</param>
        [Command("Bases-ReviveBase")]
        public void ReviveBase(int i)
        {
            if (i < 0 || i >= _baseList.Count)
            {
                Debug.LogWarning("Cannot destroy base at index, index is out of range");
                return;
            }

            _baseList[i].Revive();
        }
    }
}
