namespace Assets.Scripts.UI.SelectButtons
{
    using Assets.Project.Scripts.Other;
    using DG.Tweening;
    using UnityEngine;

    public class BridgeChoicePanel : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private Canvas _canvas;

        public void Open()
        {
            _canvas.gameObject.SetActive(true);
            _rectTransform.gameObject.SetActive(true);
            TweenHelper.ScaleUI(_rectTransform);
        }

        public void Close()
        {
            TweenHelper.HideUI(_rectTransform);

            DOTween.To(() => 0, x => { }, 1f, 0.5f)
                .SetTarget(_rectTransform)
                .OnComplete(() =>
                {
                    _rectTransform.gameObject.SetActive(false);
                    _canvas.gameObject.SetActive(false);
                });
        }
    }
}