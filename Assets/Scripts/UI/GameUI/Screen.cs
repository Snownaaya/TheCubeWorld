using Assets.Scripts.Interfaces;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.UI.GameUI
{
    public abstract class Screen : MonoBehaviour, IButtonWidget
    {
        [field: SerializeField] public RectTransform RectTransform { get; private set; }
        [field: SerializeField] public CanvasGroup CanvasGroup { get; private set; }
        [field: SerializeField] public Button Button { get; private set; }

        public abstract void Open();

        public abstract void Close();

        public void AnimatePress()
        {
            transform.DOKill();
            transform.DOScale(0.8f, 0);
        }

        public void AnimateRelease()
        {
            transform.DOKill();
            transform.DOScale(1, 0.25f).From(0.8f).SetEase(Ease.OutBack);
        }

        public void OnPointerDown(PointerEventData eventData) => AnimatePress();

        public void OnPointerUp(PointerEventData eventData) => AnimateRelease();
    }
}
