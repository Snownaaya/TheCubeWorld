using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Assets.Scripts.Interfaces;

namespace Assets.Scripts.UI.BridgeBuilder
{
    public abstract class ButtonBase : MonoBehaviour, IButtonWidget
    {
        [SerializeField] protected Button _button;

        protected virtual void OnEnable() =>
            _button.onClick.AddListener(OnClickButton);

        protected virtual void OnDisable() =>
            _button.onClick.RemoveListener(OnClickButton);


        public void OnPointerDown(PointerEventData eventData) =>
                AnimatePress();

        public void OnPointerUp(PointerEventData eventData) =>
                AnimateRelease();

        protected abstract void OnClickButton();

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
    }
}