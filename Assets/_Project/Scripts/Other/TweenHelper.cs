namespace Assets.Project.Scripts.Other
{
    using DG.Tweening;
    using UnityEngine;

    public static class TweenHelper
    {
        public static void ScaleUI(RectTransform rectTransform)
        {
            rectTransform.DOKill(false);

            rectTransform
                .DOScale(1f, 0.5f)
                .SetEase(Ease.Linear)
                .SetTarget(rectTransform);
        }

        public static void HideUI(RectTransform rectTransform)
        {
            rectTransform.DOKill(false);

            rectTransform
                .DOScale(0f, 0.5f)
                .SetEase(Ease.Linear)
                .SetTarget(rectTransform);
        }

        public static void ButtonShake(Transform transform)
        {
            transform.DOKill();

            transform.DOScale(0.8f, 0.05f)
                     .SetLoops(2, LoopType.Yoyo);
        }

        public static void HideButton(Transform transform)
        {
            transform.DOKill();

            transform.DOScale(1, 0.25f)
                .From(0.8f)
                .SetEase(Ease.OutBack);
        }
    }
}