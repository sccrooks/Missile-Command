using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Gameplay.Bases
{
    public class Base : MonoBehaviour
    {
        [Header("Base Art")]
        [SerializeField] private GameObject _baseDestroyed;
        [SerializeField] private GameObject _baseAlive;

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

        public void Destroy()
        {
           IsAlive = false;
        }

        public void Revive()
        {
            IsAlive = true;
        }
    }
}
