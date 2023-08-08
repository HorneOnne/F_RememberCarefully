using UnityEngine;
using DG.Tweening;

namespace RememberCarefully
{
    public class ScaleObjectWithDOTween : MonoBehaviour
    {
        public Transform targetTransform;
        public Vector3 targetScale = new Vector3(2f, 2f, 1f);
        public float animationDuration = 1.0f;
        public Ease easeType = Ease.OutExpo;

        private void Start()
        {
            // Scale the object at the start
            ScaleObject();
        }

        private void ScaleObject()
        {
            targetTransform.DOScale(targetScale, animationDuration)
                .SetEase(easeType)
                .OnComplete(() =>
                {
                    
                });
        }
    }
}

