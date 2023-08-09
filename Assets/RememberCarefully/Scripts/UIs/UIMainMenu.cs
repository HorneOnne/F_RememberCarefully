using UnityEngine;
using UnityEngine.UI;

namespace RememberCarefully
{
    public class UIMainMenu : CustomCanvas
    {
        [Header("Buttons")]
        [SerializeField] private Button _easyBtn;
        [SerializeField] private Button _normalBtn;
        [SerializeField] private Button _hardBtn;
        [SerializeField] private Button _expertBtn;


        private void Start()
        {
            _easyBtn.onClick.AddListener(() =>
            {
                GameManager.Instance.SetPlayingLevelData(Difficulty.EASY);
                Loader.Load(Loader.Scene.GameplayScene);

                SoundManager.Instance.PlaySound(SoundType.Button, false);
            });

            _normalBtn.onClick.AddListener(() =>
            {
                GameManager.Instance.SetPlayingLevelData(Difficulty.NORMAL);
                Loader.Load(Loader.Scene.GameplayScene);

                SoundManager.Instance.PlaySound(SoundType.Button, false);
            });

            _hardBtn.onClick.AddListener(() =>
            {
                GameManager.Instance.SetPlayingLevelData(Difficulty.HARD);
                Loader.Load(Loader.Scene.GameplayScene);

                SoundManager.Instance.PlaySound(SoundType.Button, false);
            });

            _expertBtn.onClick.AddListener(() =>
            {
                GameManager.Instance.SetPlayingLevelData(Difficulty.EXPERT);
                Loader.Load(Loader.Scene.GameplayScene);

                SoundManager.Instance.PlaySound(SoundType.Button, false);
            });

        }

        private void OnDestroy()
        {
            _easyBtn.onClick.RemoveAllListeners();
            _normalBtn.onClick.RemoveAllListeners();
            _hardBtn.onClick.RemoveAllListeners();
            _expertBtn.onClick.RemoveAllListeners();
        }
    }
}
