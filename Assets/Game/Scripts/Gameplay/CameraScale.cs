using UnityEngine;
using System.Collections;

namespace MissileCommand.Gameplay
{
    public class CameraScale : MonoBehaviour
    {
        [SerializeField] private bool _maintainWidth = true;

        private float _defaultWidth;

        private void Start()
        {
            _defaultWidth = Camera.main.orthographicSize * Camera.main.aspect;
        }

        private void Update()
        {
            if (_maintainWidth)
            {
                Camera.main.orthographicSize = _defaultWidth / Camera.main.aspect;
            }
        }
    }
}
