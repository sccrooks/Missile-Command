using MissileCommand.Controls;
using MissileCommand.Gameplay.GameController;
using MissileCommand.Gameplay.Reticle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Controls
{
    public class PlayerController : MonoBehaviour
    {
        private Controls _controls;

        [SerializeField] private ReticleController _reticle;
        [SerializeField] private float speed;

        private void Awake()
        {
            _controls = new Controls();
        }

        private void OnEnable()
        {
            _controls.Enable();
        }

        private void OnDisable()
        {
            _controls.Disable();
        }

        private void Update()
        {
            Vector2 movement = _controls.Reticle.Move.ReadValue<Vector2>();
            _reticle.Transform.position += new Vector3(movement.x * speed * Time.deltaTime, movement.y * speed * Time.deltaTime, 0);

            if (_controls.Reticle.Fire.triggered)
                Debug.Log("Fired missile");
        }
    }
}
