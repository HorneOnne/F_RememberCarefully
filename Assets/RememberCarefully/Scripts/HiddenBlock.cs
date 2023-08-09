using System.Collections;
using UnityEngine;

namespace RememberCarefully
{

    public class HiddenBlock : MonoBehaviour
    {
        public static event System.Action OnHiddenBlockClicked;

        [SerializeField] private Sprite _hideSprite;
        [SerializeField] private Sprite _showSprite;
        [SerializeField] private GameObject _hiddenObject;

        private SpriteRenderer _sr;
        private ScaleObjectWithDOTween _scaleObject;

        private bool _isShowing = false;
        public bool HasHiddenObject { get; set; } = false;

        private void Awake()
        {
            _sr = GetComponent<SpriteRenderer>();
        }

        private void Show()
        {
            _sr.sprite = _showSprite;
            _isShowing = true;


            if (HasHiddenObject)
                _hiddenObject.SetActive(true);
        }

        private void Hide()
        {
            _sr.sprite = _hideSprite;
            _isShowing = false;
            _hiddenObject.SetActive(false);
        }

        public void Toggle(float time)
        {
            Show();
            Invoke(nameof(Hide), time);
        }

        private void OnMouseDown()
        {
            if (_isShowing) return; 
            if(GameplayManager.Instance.CurrentState == GameplayManager.GameState.PLAYING)
            {
                Show();

                if (HasHiddenObject)
                {
                    GridSystem.Instance.NumOfHiddenBlockShowed++;
                    bool isWin = GridSystem.Instance.IsWinning();
                    if (isWin)
                        GameplayManager.Instance.ChangeGameState(GameplayManager.GameState.WIN);
                }
                else
                {
                    GameplayManager.Instance.ChangeGameState(GameplayManager.GameState.GAMEOVER);
                }

                SoundManager.Instance.PlaySound(SoundType.Hit, false);
                OnHiddenBlockClicked?.Invoke();
            }        
        }
    }
}

