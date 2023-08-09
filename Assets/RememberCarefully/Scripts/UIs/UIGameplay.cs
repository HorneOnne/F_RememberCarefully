using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace RememberCarefully
{
    public class UIGameplay : CustomCanvas
    {
        [Header("Buttons")]
        [SerializeField] private Button _homeBtn;

        [Header("References")]
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _remainTexts;


        private void OnEnable()
        {
            GameManager.OnScoreUp += UpdateScoreUI;
            HiddenBlock.OnHiddenBlockClicked += UpdateRemains;
        }

        
        private void OnDisable()
        {
            GameManager.OnScoreUp -= UpdateScoreUI; 
            HiddenBlock.OnHiddenBlockClicked -= UpdateRemains;
        }


        private void Start()
        {
            UpdateScoreUI();
            UpdateRemains();

            _homeBtn.onClick.AddListener(() =>
            {
                GameplayManager.Instance.ChangeGameState(GameplayManager.GameState.EXIT);
                Loader.Load(Loader.Scene.MenuScene);

                SoundManager.Instance.PlaySound(SoundType.Button, false);
            });
        }

        private void OnDestroy()
        {
            _homeBtn.onClick.RemoveAllListeners();
        }


        private void UpdateScoreUI()
        {
            _scoreText.text = GameManager.Instance.Score.ToString();
        }

        private void UpdateRemains()
        {
            _remainTexts.text = $"{GridSystem.Instance.NumOfHiddenBlockShowed}/{GameManager.Instance.PlayingLevelData.NumOfHiddenObjects}";
        }

    }
}
