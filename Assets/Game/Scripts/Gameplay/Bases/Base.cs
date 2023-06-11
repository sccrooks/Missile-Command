using MissileCommand.Infrastructure.Events;
using QFSW.QC.Actions;
using System;
using Unity.VisualScripting;
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
        public bool IsActive { get { return _isActive; } }


        [Header("Events")]
        [SerializeField] private GameEvent _baseStateChanged;

        [Header("Data")]
        [SerializeField] private TargetContainer _baseContainer;


#if UNITY_EDITOR
        private void OnValidate() { EditorApplication.delayCall += _OnValidate; }
        private void _OnValidate()
        {
            if (!EditorApplication.isPlayingOrWillChangePlaymode)
                SetActive(_isActive);
        }
#endif

        private void OnEnable()
        {
            _baseContainer.Targets.Add(this.gameObject);

            if (_isActive)
                _baseContainer.ActiveTargets.Add(gameObject);
            else
                _baseContainer.DestroyedTargets.Add(gameObject);
        }

        private void OnDisable()
        {
            _baseContainer.Targets.Remove(this.gameObject);

            if (_isActive)
                _baseContainer.ActiveTargets.Remove(this.gameObject);
            else
                _baseContainer.DestroyedTargets.Remove(this.gameObject);
        }

        /// <summary>
        /// Destroy the base
        /// </summary>
        public void Destroy()
        {
            SetActive(false);
        }

        /// <summary>
        /// Repair the base
        /// </summary>
        public void Repair()
        {
            SetActive(true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void SetActive(bool value)
        {
            // Prevent unncessary execution
            if (_isActive == value) return;

            _isActive = value;
            _baseStateChanged.Raise();

            if (!_isActive)
            {
                _baseDestroyed?.SetActive(true);
                _baseActive?.SetActive(false);
                _baseContainer.DestroyedTargets.Add(this.gameObject);
                _baseContainer.ActiveTargets.Remove(this.gameObject);
            }
            else
            {
                _baseDestroyed?.SetActive(false);
                _baseActive?.SetActive(true);
                _baseContainer.DestroyedTargets.Remove(this.gameObject);
                _baseContainer.ActiveTargets.Add(this.gameObject);
            }
        }
    }
}
