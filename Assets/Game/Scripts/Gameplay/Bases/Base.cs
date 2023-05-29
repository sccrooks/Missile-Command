using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Gameplay.Bases
{
    /// <summary>
    /// Used for storing base data and individual base actions.
    /// </summary>
    public class Base : MonoBehaviour
    {
        [Header("Base Art")]
        [SerializeField] private GameObject _baseAlive;
        [SerializeField] private GameObject _baseDestroyed;

        [Header("Base Stats")]
        [SerializeField] private bool _isAlive;
        public bool IsAlive 
        { 
            get { return _isAlive; } 
            private set 
            { 
                _isAlive = value;

                if (!_isAlive)
                {
                    _baseDestroyed.SetActive(true);
                    _baseAlive.SetActive(true);
                } else
                {
                    _baseDestroyed.SetActive(false);
                    _baseAlive.SetActive(true);
                }
            }
        }

        /// <summary>
        /// Destroy the base
        /// </summary>
        public void Destroy()
        {
           IsAlive = false;
        }

        /// <summary>
        /// Revive the base
        /// </summary>
        public void Revive()
        {
            IsAlive = true;
        }
    }
}
