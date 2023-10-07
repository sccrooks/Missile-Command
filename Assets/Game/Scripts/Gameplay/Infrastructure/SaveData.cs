using MissileCommand.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Infrastructure
{
    [System.Serializable]
    public class SaveData
    {
        public List<Score> HighscoreData = new List<Score>();
    }
}
