using MissileCommand.Gameplay;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.UI.HUD
{
    public class AmmoUpdater : MonoBehaviour
    {
        [SerializeField] private Ammo _ammo;
        [SerializeField] private GameObject _ammoPrefab;

        private List<GameObject> _ammoGameobjects = new List<GameObject>();

        // Start is called before the first frame update
        void Start()
        {
            updateDisplay();
        }

        /// <summary>
        /// Updates ammo count on HUD
        /// </summary>
        public void updateDisplay()
        {
            int ammo = _ammo.RuntimeValue;

            // Delete spent ammo
            while (_ammoGameobjects.Count < ammo)
            {
                GameObject ammoGameobject = Instantiate(_ammoPrefab, transform);
                _ammoGameobjects.Add(ammoGameobject);
            }

            // Add new ammo
            while (_ammoGameobjects.Count > ammo)
            {
                GameObject gameObject = _ammoGameobjects[_ammoGameobjects.Count - 1];
                _ammoGameobjects.Remove(gameObject);
                Destroy(gameObject);
            }
        }
    }
}
