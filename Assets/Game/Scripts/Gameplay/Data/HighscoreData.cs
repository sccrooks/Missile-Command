using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Gameplay.Data
{
    [System.Serializable]
    public struct Score
    {
        public Score(string user, int value)
        {
            User = user;
            Value = value;
        }

        public string User;
        public int Value;
    }

    [System.Serializable, CreateAssetMenu(fileName = "HighscoreData", menuName = "HighscoreData")]
    public class HighscoreData : ScriptableObject
    {
        public List<Score> Highscores = new List<Score>();
        public int MaxHighscores = 5;
    }
}
