using UnityEngine;

namespace MissileCommand.Gameplay.Cannon
{
    public class Cannon : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private GameObject _barrelAxis;
        [SerializeField] private GameObject _reticle;

        [Header("Settings")]
        [SerializeField] private float _angleModifier;

        private void Update()
        {
            Vector3 relativePos = _barrelAxis.transform.position - _reticle.transform.position;
            float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;
            _barrelAxis.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            _barrelAxis.transform.Rotate(Vector3.forward, _angleModifier);
        }

    }
}