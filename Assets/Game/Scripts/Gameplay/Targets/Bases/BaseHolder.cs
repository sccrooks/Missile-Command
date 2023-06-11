using MissileCommand.Infrastructure.Events;
using QFSW.QC;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace MissileCommand.Gameplay.Bases
{
    public class BaseHolder : MonoBehaviour
    {
        [SerializeField]
        private List<Base> _bases = new List<Base>();

        [SerializeField]
        private int _activeBases;


        [Header("Events")]
        [SerializeField] private GameEvent _allBasesDestroyed;

        private void Start()
        {
            ValidateActiveBases();
        }

        public void ValidateActiveBases()
        {
            _activeBases = getTotalActivebases();

            if (_activeBases <= 0)
            {
                Debug.Log("[GameController] All bases destroyed");
                _allBasesDestroyed.Raise();
            }
        }

        /// <summary>
        /// Searchs bases list and returns total number of alive bases
        /// </summary>
        /// <returns>Total number of alive bases</returns>
        private int getTotalActivebases()
        {
            int active = 0;

            foreach (Base @base in _bases)
            {
                if (@base.IsActive)
                    active++;
            }

            return active;
        }


        #region Commands
        /// <summary>
        /// Destroy a base at index
        /// </summary>
        /// <param name="index">Index of base to destroy</param>
        [Command("Bases-Destroy")]
        public void DestroyBase(int index)
        {
            if (index < 0 || index >= _bases.Count)
            {
                Debug.LogWarning("Cannot destroy base at index, index is out of range");
                return;
            }

            _bases[index].Destroy();
        }

        /// <summary>
        /// Revive a base at index
        /// </summary>
        /// <param name="index">Index of base to revive</param>
        [Command("Bases-Repair")]
        public void RepairBase(int index)
        {
            if (index < 0 || index >= _bases.Count)
            {
                Debug.LogWarning("Cannot revive base at index, index is out of range");
                return;
            }

            _bases[index].Repair();
        }
        #endregion
    }
}
