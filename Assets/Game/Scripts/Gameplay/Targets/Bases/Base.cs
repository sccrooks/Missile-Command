using MissileCommand.Infrastructure.Events;
using QFSW.QC.Actions;
using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace MissileCommand.Gameplay.Targets.Bases
{
    /// <summary>
    /// Used for storing base data and individual base actions.
    /// </summary>
    public class Base : Target
    {
        [Header("Base Art")]
        [SerializeField] private GameObject _baseActive;
        [SerializeField] private GameObject _baseDestroyed;

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
        public override void SetActive(bool value)
        {
            base.SetActive(value);

            // Change base graphics
            if (Active)
            {
                _baseActive?.SetActive(true);
                _baseDestroyed?.SetActive(false);
            }
            else
            {
                _baseActive?.SetActive(false);
                _baseDestroyed?.SetActive(true);
            }
        }
    }
}
