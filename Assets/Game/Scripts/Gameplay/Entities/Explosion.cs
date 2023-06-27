using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Gameplay.Entities
{
    public class Explosion : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private SpriteRenderer _renderer;
        [SerializeField] private CircleCollider2D _collider;

        [Header("Settings")]
        [SerializeField, Min(0)] private float _effectDuration = 0f;
        [SerializeField, Min(0)] private float _damageDuration = 0f;
        [SerializeField, Min(1)] private float _size = 1f;

        private float _timeAlive = 0;

        private void Start()
        {
            _renderer = this.gameObject.GetComponent<SpriteRenderer>();
            _collider = this.gameObject.GetComponent<CircleCollider2D>();
            this.gameObject.transform.localScale = new Vector3(_size, _size, 1);
        }

        private void Update()
        {
            _timeAlive += Time.deltaTime;

            if (_timeAlive > _damageDuration)
                _collider.radius = 0;

            if (_timeAlive >= _effectDuration)
                Destroy(this.gameObject);
        }
    }
}
