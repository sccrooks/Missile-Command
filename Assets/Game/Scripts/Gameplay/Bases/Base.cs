using System;
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
                _isActive = value;

                if (!_isActive)
                {
                    _baseDestroyed.SetActive(true);
                    _baseActive.SetActive(false);
                    BaseDestroyed?.Invoke();
                } else
                {
                    _baseDestroyed.SetActive(false);
                    _baseActive.SetActive(true);
                    BaseRepaired?.Invoke();
                }
            }
        }

        public event Action BaseDestroyed;
        public event Action BaseRepaired;

#if UNITY_EDITOR
        private void OnValidate() { UnityEditor.EditorApplication.delayCall += _OnValidate; }
        private void _OnValidate()
        {
            IsActive = _isActive;
        }
#endif

        /// <summary>
        /// Destroy the base
        /// </summary>
        public void Destroy()
        {
            if (IsActive)
                IsActive = false;
        }

        /// <summary>
        /// Repair the base
        /// </summary>
        public void Repair()
        {
            if (!IsActive)
                IsActive = true;
        }
    }
}
