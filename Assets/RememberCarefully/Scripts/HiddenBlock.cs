using System.Collections;
using UnityEngine;

namespace RememberCarefully
{

    public class HiddenBlock : MonoBehaviour
    {
        [SerializeField] private Sprite _hideSprite;
        [SerializeField] private Sprite _showSprite;
        [SerializeField] private GameObject _hiddenObject;

        private SpriteRenderer _sr;
        private ScaleObjectWithDOTween _scaleObject;

        public bool HasHiddenObject { get; set; } = false;

        private void Awake()
        {
            _sr = GetComponent<SpriteRenderer>();
        }

        private void Show()
        {
            _sr.sprite = _showSprite;
            
            if(HasHiddenObject)
                _hiddenObject.SetActive(true);
        }

        private void Hide()
        {
            _sr.sprite = _hideSprite;
            _hiddenObject.SetActive(false);
        }

        public void Toggle(float time)
        {
            Show();
            Invoke(nameof(Hide), time);
        }

        private void OnMouseDown()
        {
            Show();


            if(HasHiddenObject)
            {
                GridSystem.Instance.NumOfHiddenBlockShowed++;
                bool isWin = GridSystem.Instance.IsWinning();
                Debug.Log(isWin);
            }
            else
            {
                Debug.Log("Game over");
            }
            
        }
    }
}

