using Mono.CSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MissileCommand.UI.HUD
{
    public class ScoreUpdater : MonoBehaviour
    {
        [SerializeField] private TMP_Text _tmpText;

        public void UpdateScore(int score) => _tmpText.text = Convert.ToString(score);
    }
}
