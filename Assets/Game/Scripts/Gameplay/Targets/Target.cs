using MissileCommand.Gameplay.Bases;
using MissileCommand.Infrastructure.Events;
using System.Collections;
using UnityEditor;
using UnityEngine;

namespace MissileCommand.Gameplay.Targets
{
    public class Target : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] private TargetContainer _targetContainer;

        [Header("Events")]
        [SerializeField] private GameEvent _targetStateChanged;

        private bool _active;
        public bool Active { get; private set; } = true;

        /// <summary>
        /// Annoying onvalidate method to prevent errors while in editor.
        /// </summary>
        #region
#if UNITY_EDITOR
        private void OnValidate() { EditorApplication.delayCall += _OnValidate; }
        private void _OnValidate()
        {
            if (!EditorApplication.isPlayingOrWillChangePlaymode)
                SetActive(_active);
        }
#endif
        #endregion

        private void OnEnable()
        {
            _targetContainer.Targets.Add(this.gameObject);

            if (Active)
                _targetContainer.ActiveTargets.Add(this.gameObject);
            else
                _targetContainer.DestroyedTargets.Add(this.gameObject);
        }

        private void OnDisable()
        {
            _targetContainer.Targets.Remove(this.gameObject);

            if (Active)
                _targetContainer.ActiveTargets.Remove(this.gameObject);
            else
                _targetContainer.DestroyedTargets.Remove(this.gameObject);
        }

        public virtual void SetActive(bool value)
        {
            // Prevent unneccessary code execution
            if (value == Active) return;
            Active = value;
            _targetStateChanged.Raise();

            if (Active)
            {
                _targetContainer.ActiveTargets.Add(this.gameObject);
                _targetContainer.DestroyedTargets.Remove(this.gameObject);
            } else
            {
                _targetContainer.ActiveTargets.Remove(this.gameObject);
                _targetContainer.DestroyedTargets.Add(gameObject);
            }
        }
    }
}