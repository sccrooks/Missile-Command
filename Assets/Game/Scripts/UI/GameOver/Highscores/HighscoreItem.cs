using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MissileCommand.UI.GameOver
{
    public class HighscoreItem : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private TMP_Text _usernameText;
        [SerializeField] private TMP_Text _scoreText;

        public TMP_Text UsernameText
        { get { return _usernameText; } set { _usernameText = value; } }
        public TMP_Text ScoreText
        { get { return _scoreText; } set { _scoreText = value; } }
    }
}
