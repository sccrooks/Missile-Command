using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.UI.GameOver
{
    public struct Highscore
    {
        public Highscore(string user, int score)
        {
            User = user;
            Score = score;
        }

        public string User;
        public int Score;
    }

    public class HighscoreDisplay : MonoBehaviour
    {
        [SerializeField] private List<HighscoreItem> _highscoreItems = new List<HighscoreItem>();
        private List<Highscore> _highscores = new List<Highscore>();

        private void Start()
        {
            _highscores.Add(new Highscore("Scott", 1000));
            _highscores.Add(new Highscore("Scott", 2000));
            _highscores.Add(new Highscore("Scott", 3000));
            _highscores.Add(new Highscore("Scott", 4000));
            _highscores.Add(new Highscore("Scott", 5000));

            for (int i = 0; i < _highscoreItems.Count; i++)
            {
                _highscoreItems[i].SetContent(_highscores[i].User, _highscores[i].Score);
            }    
        }
    }
}
