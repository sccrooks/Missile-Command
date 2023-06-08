using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MissileCommand.Gameplay
{
    public class CollisionReciever : MonoBehaviour
    {
        public string _tag;
        public UnityEvent _event;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(_tag))
                _event?.Invoke();
        }
    }
}