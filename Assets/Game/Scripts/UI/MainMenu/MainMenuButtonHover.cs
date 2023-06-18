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
        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _tmpText;

        [Header("Settings")]
        [SerializeField] private float _size = 32f;
        [SerializeField] private float _hoverSize = 48f;
        [SerializeField] private string _text;
        [SerializeField] private string _hoverText;

        public void OnPointerEnter(PointerEventData eventData)
        {
            _tmpText.text = _hoverText;
            _tmpText.fontSize = _hoverSize;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _tmpText.text = _text;
            _tmpText.fontSize = _size;
        }
    }
}
