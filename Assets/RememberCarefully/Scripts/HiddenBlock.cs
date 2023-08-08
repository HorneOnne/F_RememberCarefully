using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RememberCarefully
{
    public class HiddenBlock : MonoBehaviour
    {
        [SerializeField] private Sprite _hideSprite;
        [SerializeField] private Sprite _showSprite;
        [SerializeField] private GameObject _hiddenObject;


        private SpriteRenderer _sr;

        private void Awake()
        {
            _sr = GetComponent<SpriteRenderer>();
        }

        private void Show()
        {
            _sr.sprite = _showSprite;
            _hiddenObject.SetActive(true);
        }

        private void Hide()
        {
            _sr.sprite = _hideSprite;
            _hiddenObject.SetActive(false);
        }

        private void OnMouseDown()
        {
            Debug.Log("Mouse down");
            Show();
            Invoke(nameof(Hide), 0.5f);
        }
    }
}

