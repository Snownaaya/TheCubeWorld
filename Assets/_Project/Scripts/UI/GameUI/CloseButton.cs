 namespace Assets.Project.Scripts.UI.GameUI
{
    using System;
    using Assets.Project.Scripts.Other;
    using Assets.Scripts.Interfaces;
    using DG.Tweening;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;

    public class CloseButton : MonoBehaviour, IButtonWidget
    {
        [SerializeField] private Button _button;

        public event Action Clicked;

        private void OnEnable() =>
            _button.onClick.AddListener(OnClick);

        private void OnDisable() =>
            _button.onClick.RemoveListener(OnClick);

        public void OnPointerDown(PointerEventData eventData) => AnimatePress();

        public void OnPointerUp(PointerEventData eventData) => AnimateRelease();

        public void AnimatePress()
        {
            transform.DOKill();
            transform.DOScale(0.8f, 0);
        }

        public void AnimateRelease()
        {
            TweenHelper.ButtonShake(transform);
        }

        private void OnClick() =>
            Clicked?.Invoke();
    }
}