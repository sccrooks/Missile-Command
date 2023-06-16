using UnityEngine;

namespace MissileCommand.Gameplay.Targets.Bases
{
    /// <summary>
    /// Used for storing base data and individual base actions.
    /// </summary>
    public class Base : Target
    {
        [Header("Base Art")]
        [SerializeField] private Sprite _baseActive;
        [SerializeField] private Sprite _baseDestroyed;
        [SerializeField] private SpriteRenderer _graphics;

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
        public void SetActive(bool value)
        {
            base.SetActive(value);

            // Change base graphics
            if (Active)
            {
                _graphics.sprite = _baseActive;
            }
            else
            {
                _graphics.sprite = _baseDestroyed;
            }
        }
    }
}
