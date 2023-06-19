using UnityEngine;
using System.Collections;

namespace MissileCommand.Gameplay
{
    public class CameraScale : MonoBehaviour
    {
        [SerializeField] private bool _maintainWidth = true;
        [SerializeField] private float _heightOffset = 0f;

        private float _defaultWidth;
        private float _defaultHeight;
        private Vector3 _cameraPosition;

        private void Start()
        {
            _cameraPosition = Camera.main.transform.position;

            _defaultHeight = Camera.main.orthographicSize;
            _defaultWidth = Camera.main.orthographicSize * Camera.main.aspect;
        }

        private void Update()
        {
            if (_maintainWidth)
            {
                Camera.main.orthographicSize = _defaultWidth / Camera.main.aspect;

                Camera.main.transform.position = new Vector3(_cameraPosition.x, -1 * (_defaultHeight - Camera.main.orthographicSize) + _heightOffset, _cameraPosition.z);
            }
        }
    }
}
