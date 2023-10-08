using UnityEngine;
using TMPro;

namespace MissileCommand.UI.GameOver
{
    public class HighscoreItem : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private TMP_Text _usernameText;
        [SerializeField] private TMP_Text _scoreText;

        public void SetContent(string username, string score)
        {
            _usernameText.text = username;
            _scoreText.text = score;
        }
    }
}
