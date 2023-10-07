using System.Collections.Generic;

namespace MissileCommand.Gameplay.Data
{
    [System.Serializable]
    public class SaveData
    {
        public List<Score> HighscoreData = new List<Score>();
    }
}
