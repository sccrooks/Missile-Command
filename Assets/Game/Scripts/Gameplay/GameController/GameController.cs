using MissileCommand.Gameplay.Bases;
using ModestTree.Util;
using QFSW.QC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MissileCommand.Gameplay.GameController
{
    public class GameController : MonoBehaviour
    {
        public static GameController Instance { get; private set; }

        [Header("Components")]
        [SerializeField] private SceneData _sceneData;
        [SerializeField] private ILevelController _levelController;
        [SerializeField] private BaseHolder _baseHolder;

        [Header("Game stats")]
        [SerializeField] private int score;


        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            _baseHolder.AllBasesDestroyed += OnAllBasesDestroyed;
        }

        private void OnDestroy()
        {
            _baseHolder.AllBasesDestroyed -= OnAllBasesDestroyed;
        }

        private void OnAllBasesDestroyed()
        {
            EndGame();
        }


        [Command]
        private void EndGame()
        {
            SceneManager.LoadScene(_sceneData.GameOver);
        }
    }
}
