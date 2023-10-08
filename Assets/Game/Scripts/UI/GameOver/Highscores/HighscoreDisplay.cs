using MissileCommand.Gameplay.Data;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.UI.GameOver
{
    public class HighscoreDisplay : MonoBehaviour
    {
        [SerializeField] private List<HighscoreItem> _highscoreItems = new List<HighscoreItem>();

        [SerializeField] private HighscoreData _scoreData;

        private void Start()
        {

            for (int i = 0; i < _highscoreItems.Count; i++)
            {

                // TODO: Fix out of bounds error
                if (i > _scoreData.Highscores.Count - 1)
                    _highscoreItems[i].SetContent("", "");
                else
                    _highscoreItems[i].SetContent(_scoreData.Highscores[i].User, _scoreData.Highscores[i].Value.ToString());
            }
        }
    }
}
