using Sccrooks.Utility.ScriptableObjects.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Gameplay
{
    public class ColourChanger : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _renderer;

        private void OnValidate()
        {
            _renderer = this.gameObject.GetComponent<SpriteRenderer>();
        }

        public void ChangeColour(Color colour)
        {
            _renderer.color = colour;
        }
    }
}
