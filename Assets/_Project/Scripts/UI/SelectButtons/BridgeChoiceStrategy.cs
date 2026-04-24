namespace Assets.Project.Scripts.UI.SelectButtons
{
    using Assets.Project.Scripts.Other;
    using DG.Tweening;
    using UnityEngine;

    public abstract class BridgeChoiceStrategy : MonoBehaviour
    {
        [field: SerializeField] public RectTransform RectTransform { get; private set; }

        [field: SerializeField] public Canvas Canvas { get; private set; }

        public virtual void Open()
        {
            Canvas.gameObject.SetActive(true);
            TweenHelper.ScaleUI(RectTransform);

            if (RectTransform == null)
                return;

            RectTransform.gameObject.SetActive(true);
        }

        public virtual void Close()
        {
            TweenHelper.HideUI(RectTransform);

            DOTween.To(() => 0, x => { }, 1f, 0.5f)
                .SetTarget(RectTransform)
                .OnComplete(() =>
                {
                    RectTransform.gameObject.SetActive(false);
                    Canvas.gameObject.SetActive(false);
                });
        }
    }
}