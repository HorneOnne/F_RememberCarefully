using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace RememberCarefully
{
    public class UIGameover : CustomCanvas
    {
        [Header("Buttons")]
        [SerializeField] private Button _restartBtn;
        [SerializeField] private Button _homeBtn;


        [Header("Texts")]
        [SerializeField] private TextMeshProUGUI _difficultyText;
        [SerializeField] private TextMeshProUGUI _scoreText;


        private void OnEnable()
        {
            GameManager.OnScoreUp += UpdateScoreUI;
            GameManager.OnScoreUp += UpdateDifficultUI;
        }

        private void OnDisable()
        {
            GameManager.OnScoreUp -= UpdateScoreUI;
            GameManager.OnScoreUp -= UpdateDifficultUI;
        }

  
        private void Start()
        {
            UpdateScoreUI();
            UpdateDifficultUI();

            _restartBtn.onClick.AddListener(() =>
            {
                Loader.Load(Loader.Scene.GameplayScene);

                SoundManager.Instance.PlaySound(SoundType.Button, false);
            });

            _homeBtn.onClick.AddListener(() =>
            {
                Loader.Load(Loader.Scene.MenuScene);

                SoundManager.Instance.PlaySound(SoundType.Button, false);
            });
        }

        private void OnDestroy()
        {
            _restartBtn.onClick.RemoveAllListeners();
            _homeBtn.onClick.RemoveAllListeners();
        }


        private void UpdateScoreUI()
        {
            _scoreText.text = $"SCORE {GameManager.Instance.Score}";
        }

        private void UpdateDifficultUI()
        {
            _difficultyText.text = GameManager.Instance.PlayingLevelData.Difficulty.ToString();
        }
    }
}
