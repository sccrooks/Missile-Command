using UnityEngine;

namespace MissileCommand.Gameplay.Cannon
{
    public class Cannon : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private GameObject _barrelAxis;
        [SerializeField] private GameObject _reticle;
        [SerializeField] private GameObject _barrelTip;

        [Header("Audio")]
        [SerializeField] private AudioSource _audioSource;

        [Header("Settings")]
        [SerializeField] private float _angleModifier;
        [SerializeField] private GameObject _defenceMissile;
        [SerializeField] private int _maxAmmo = 20;
        [SerializeField] private Ammo _ammo;

        private void OnValidate()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            Vector3 relativePos = _barrelAxis.transform.position - _reticle.transform.position;
            float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;
            _barrelAxis.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            _barrelAxis.transform.Rotate(Vector3.forward, _angleModifier);
        }

        /// <summary>
        /// Fire event listener
        /// </summary>
        public void OnFireEvent()
        {
            if (_ammo.RuntimeValue > 0)
            {
                _ammo.RuntimeValue--;
                _audioSource.Play(0);
                Instantiate(_defenceMissile, _barrelTip.transform.position, Quaternion.identity, this.gameObject.transform);
            }
        }

        /// <summary>
        /// Event listerner for level started event,
        /// used for restocking turret ammo.
        /// </summary>
        public void OnLevelStartEvent()
        {
            _ammo.RuntimeValue = _maxAmmo;
        }
    }
}