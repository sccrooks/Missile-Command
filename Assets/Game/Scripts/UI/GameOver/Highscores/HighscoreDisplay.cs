using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.UI.GameOver
{
    public class HighscoreDisplay : MonoBehaviour
    {
        [SerializeField] private List<HighscoreItem> _highscoreItems = new List<HighscoreItem>();
    }
}
