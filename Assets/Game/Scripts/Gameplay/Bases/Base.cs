using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Gameplay.Bases
{
    /// <summary>
    /// Used for storing base data and individual base actions.
    /// </summary>
    public class Base : MonoBehaviour
    {
        [Header("Base Art")]
        [SerializeField] private GameObject _baseAlive;
        [SerializeField] private GameObject _baseDestroyed;

        [Header("Base Stats")]
        [SerializeField] private bool _isAlive;
        public bool IsAlive 
        { 
            get { return _isAlive; } 
            private set 
            { 
                _isAlive = value;

                if (!_isAlive)
                {
                    _baseDestroyed.SetActive(true);
                    _baseAlive.SetActive(false);
                    BaseDestroyed?.Invoke();
                } else
                {
                    _baseDestroyed.SetActive(false);
                    _baseAlive.SetActive(true);
                    BaseRevived?.Invoke();
                }
            }
        }

        public event Action BaseDestroyed;
        public event Action BaseRevived;

#if UNITY_EDITOR
        private void OnValidate() { UnityEditor.EditorApplication.delayCall += _OnValidate; }
        private void _OnValidate()
        {
            IsAlive = _isAlive;
        }
#endif

        /// <summary>
        /// Destroy the base
        /// </summary>
        public void Destroy()
        {
            if (IsAlive)
                IsAlive = false;
        }

        /// <summary>
        /// Revive the base
        /// </summary>
        public void Revive()
        {
            if (!IsAlive)
                IsAlive = true;
        }
    }
}
