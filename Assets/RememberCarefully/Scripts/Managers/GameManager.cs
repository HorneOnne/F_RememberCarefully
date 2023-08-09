using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

namespace RememberCarefully
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        public static event System.Action OnScoreUp;

        // SCORE & BEST
        private int _score;
        private int _bestScore;

        // RememberCarefully Properties
        [SerializeField] private List<LevelData> _levels;
        public LevelData PlayingLevelData { get; private set; } 


        #region Properties
        public int Score { get => _score; }
        public int BestScore { get => _bestScore; }
        #endregion


        #region Init
        private void Awake()
        {
            // Check if an instance already exists, and destroy the duplicate
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;

            // FPS
            Application.targetFrameRate = 60;
        }

        private void Start()
        {
            // Make the GameObject persist across scenes
            DontDestroyOnLoad(this.gameObject);
        }
        #endregion


        #region SCORE
        public void ScoreUp()
        {
            _score++;
            OnScoreUp?.Invoke();
        }

        public void ResetScore()
        {
            this._score = 0;
        }

        public void SetBestScore(int score)
        {
            this._score = score;
            if (_bestScore < score)
            {
                _bestScore = score;
            }
        }
        #endregion


        #region RememberCarefully methods
        private LevelData GetLevelData(Difficulty difficulty)
        {
            for(int i = 0; i < _levels.Count; i++)
            {
                if (_levels[i].Difficulty == difficulty)
                    return _levels[i];
            }

            return _levels[0];
        }

        public void SetPlayingLevelData(Difficulty difficulty)
        {
            this.PlayingLevelData = GetLevelData(difficulty);
        }
        #endregion

    }
}
