using System;
using UnityEditor;
using UnityEngine;

namespace MissileCommand.Gameplay.Bases
{
    /// <summary>
    /// Used for storing base data and individual base actions.
    /// </summary>
    public class Base : MonoBehaviour
    {
        [Header("Base Art")]
        [SerializeField] private GameObject _baseActive;
        [SerializeField] private GameObject _baseDestroyed;

        [Header("Base Stats")]
        [SerializeField] private bool _isActive;
        public bool IsActive 
        { 
            get { return _isActive; } 
            private set 
            {
                // Prevent changing base active status if new value is the same as old
                if (_isActive == value) return;

                _isActive = value;

                if (!_isActive)
                {
                    _baseDestroyed?.SetActive(true);
                    _baseActive?.SetActive(false);
                    BaseDestroyed?.Invoke();
                } else
                {
                    _baseDestroyed?.SetActive(false);
                    _baseActive?.SetActive(true);
                    BaseRepaired?.Invoke();
                }
            }
        }

        public event Action BaseDestroyed;
        public event Action BaseRepaired;

#if UNITY_EDITOR
        private void OnValidate() { EditorApplication.delayCall += _OnValidate; }
        private void _OnValidate()
        {
            if (!EditorApplication.isPlayingOrWillChangePlaymode)
                IsActive = _isActive;
        }
#endif

        /// <summary>
        /// Destroy the base
        /// </summary>
        public void Destroy()
        {
            IsActive = false;
        }

        /// <summary>
        /// Repair the base
        /// </summary>
        public void Repair()
        {
            IsActive = true;
        }
    }
}
