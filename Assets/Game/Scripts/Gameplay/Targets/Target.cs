using Sccrooks.Utility.ScriptableObjects.Events;
using UnityEditor;
using UnityEngine;

namespace MissileCommand.Gameplay.Targets
{
    public class Target : MonoBehaviour
    {

        [Header("Status")]
        [SerializeField] private bool _active;
        public bool Active { get { return _active; } private set { _active = value; } }

        [Header("Data")]
        [SerializeField] private TargetContainer _targetContainer;

        [Header("Events")]
        [SerializeField] private GameEvent _targetStateChanged;

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
                _targetContainer.DeactivatedTargets.Add(this.gameObject);
        }

        private void OnDisable()
        {
            _targetContainer.Targets.Remove(this.gameObject);

            if (Active)
                _targetContainer.ActiveTargets.Remove(this.gameObject);
            else
                _targetContainer.DeactivatedTargets.Remove(this.gameObject);
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
                _targetContainer.DeactivatedTargets.Remove(this.gameObject);
            } else
            {
                _targetContainer.ActiveTargets.Remove(this.gameObject);
                _targetContainer.DeactivatedTargets.Add(this.gameObject);
            }
        }
    }
}
