using MissileCommand.Gameplay;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.UI.GameOver
{
    public class HighscoreDisplay : MonoBehaviour
    {
        [SerializeField] private List<HighscoreItem> _highscoreItems = new List<HighscoreItem>();

        [SerializeField] private ScoreData _scoreData;

        private void Start()
        {

            for (int i = 0; i < _highscoreItems.Count; i++)
            {
                _highscoreItems[i].SetContent(_scoreData._highscores[i].User, _scoreData._highscores[i].Value);
            }    
        }
    }
}
