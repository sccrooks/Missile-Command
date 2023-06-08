using MissileCommand.Infrastructure.Events;
using QFSW.QC;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace MissileCommand.Gameplay.Bases {
    public class BaseHolder : MonoBehaviour
    {
        [SerializeField]
        private List<Base> _bases = new List<Base>();

        [SerializeField]
        private int _activeBases;
        public int ActiveBases
        {
            get => _activeBases;
            private set
            {
                _activeBases = value;
                if (_activeBases <= 0)
                    _allBasesDestroyed.Raise();
            }
        }

        [Header("Events")]
        [SerializeField] private GameEvent _allBasesDestroyed;

        #region -- Start, OnValidate, OnDestroy --
        private void Start()
        {
            foreach (Base @base in _bases)
            {
                @base.BaseDestroyed += OnBaseDestroyed;
                @base.BaseRepaired += OnBaseRepaired;
            }

            ActiveBases = getTotalActivebases();
        }

        private void OnDestroy()
        {
            foreach (Base @base in _bases)
            {
                @base.BaseDestroyed -= OnBaseDestroyed;
                @base.BaseRepaired -= OnBaseRepaired;
            }
        }

        private void OnValidate()
        {
#if UNITY_EDITOR
            if (!EditorApplication.isPlayingOrWillChangePlaymode)
                ActiveBases = getTotalActivebases();
#endif
        }
        #endregion

        /// <summary>
        /// Destroy a base at index
        /// </summary>
        /// <param name="index">Index of base to destroy</param>
        [Command("Bases-DestroyBase")]
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
        [Command("Bases-ReviveBase")]
        public void RepairBase(int index)
        {
            if (index < 0 || index >= _bases.Count)
            {
                Debug.LogWarning("Cannot revive base at index, index is out of range");
                return;
            }

            _bases[index].Repair();
        }

        /// <summary>
        /// Event subscriber for Base Destroyed event
        /// </summary>
        private void OnBaseDestroyed()
        {
            ActiveBases--;
        }

        /// <summary>
        /// Event subscriber for Base Revived event
        /// </summary>
        private void OnBaseRepaired()
        {
            ActiveBases++;
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
    }
}
