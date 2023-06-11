using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MissileCommand.Gameplay
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
    public class CollisionReciever2D : MonoBehaviour
    {
        public string _tag;
        public UnityEvent _event;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == _tag)
                _event?.Invoke();
        }
    }
}