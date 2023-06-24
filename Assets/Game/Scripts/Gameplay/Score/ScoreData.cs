using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Gameplay
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

    [CreateAssetMenu(fileName = "Score Data", menuName = "ScoreData")]
    public class ScoreData : ScriptableObject
    {
        public List<Score> _highscores = new List<Score>();
    }
}
