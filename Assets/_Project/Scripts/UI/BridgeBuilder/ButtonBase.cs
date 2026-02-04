using Assets.Scripts.Interfaces;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Assets.Scripts.UI.BridgeBuilder
{
    public abstract class ButtonBase : MonoBehaviour, IButtonWidget
    {
        [field: SerializeField] public Button Button { get; private set; }

        protected virtual void OnEnable() =>
            Button.onClick.AddListener(OnClickButton);

        protected virtual void OnDisable() =>
            Button.onClick.RemoveListener(OnClickButton);

        public void OnPointerDown(PointerEventData eventData) => AnimatePress();

        public void OnPointerUp(PointerEventData eventData) => AnimateRelease();

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

        protected abstract void OnClickButton();
    }
}