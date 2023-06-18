using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MissileCommand.UI.MainMenu
{
    public class MainMenuButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [Header("Components")]
        [SerializeField] private TMP_Text _tmpText;

        [Header("Settings")]
        [SerializeField] private float _size = 32f;
        [SerializeField] private float _hoverSize = 38f;
        [SerializeField] private string _text;
        [SerializeField] private string _hoverText;
        [SerializeField] private Color _color = Color.white;
        [SerializeField] private Color _hoverColor = Color.white;
        [SerializeField] private bool _startSelected;

        private void OnValidate()
        {
            if (_startSelected)
            {
                _tmpText.text = _hoverText;
                _tmpText.fontSize = _hoverSize;
                _tmpText.color = _hoverColor;
            }
            else
            {
                _tmpText.text = _text;
                _tmpText.fontSize = _size;
                _tmpText.color = _color;
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _tmpText.text = _hoverText;
            _tmpText.fontSize = _hoverSize;
            _tmpText.color = _hoverColor;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _tmpText.text = _text;
            _tmpText.fontSize = _size;
            _tmpText.color = _color;
        }
    }
}
