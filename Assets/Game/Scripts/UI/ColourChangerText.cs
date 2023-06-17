using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MissileCommand.UI
{
    public class ColourChangerText : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _tmpText;

        private void OnValidate()
        {
            _tmpText = this.gameObject.GetComponent<TMP_Text>();
        }

        public void ChangeColour(Color colour)
        {
            _tmpText.color = colour;
        }
    }
}
