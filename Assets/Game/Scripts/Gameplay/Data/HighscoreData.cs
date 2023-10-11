using System;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Gameplay.Data
{
    [System.Serializable]
    public class Score : IComparable<Score>
    {
        public Score(string user, int value)
        {
            User = user;
            Value = value;
        }

        public string User;
        public int Value;

        public int CompareTo(Score other)
        {
            if (this.Value < other.Value) return -1;
            if (this.Value == other.Value) return 0;
            return 1;
        }
    }

    [System.Serializable, CreateAssetMenu(fileName = "HighscoreData", menuName = "HighscoreData")]
    public class HighscoreData : ScriptableObject
    {
        public List<Score> Highscores = new List<Score>();
        public int MaxHighscores = 5;

        public void AddHighscore(string name, int score)
        {
            Highscores.Add(new Score(name, score));
            Highscores.Sort();
            Highscores.Reverse();

            if (Highscores.Count > MaxHighscores)
                Highscores.RemoveRange(MaxHighscores - 1, Highscores.Count - MaxHighscores);
        }
    }
}
