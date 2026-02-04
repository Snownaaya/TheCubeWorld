using Assets.Scripts.UI.GameUI;
using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Shop.Buttons
{
    public class BuyButton : UIElement
    {
        [SerializeField] private Button _buyButton;
        [SerializeField] private RectTransform _buyRectTransform;

        [SerializeField, Range(0, 1)] private float _lockAnimationDuration = 0.4f;
        [SerializeField, Range(0.5f, 5)] private float _lockAnimationStrength = 2f;

        public event Action Clicked;

        private void OnEnable() =>
            _buyButton.onClick.AddListener(OnClick);

        private void OnDisable() =>
            _buyButton.onClick.RemoveListener(OnClick);

        public override void Show() =>
            _buyButton.gameObject.SetActive(true);

        public override void Hide() =>
            _buyButton.gameObject.SetActive(false);

        private void OnClick()
        {
            Clicked?.Invoke();

            _buyButton.transform.DOShakePosition(_lockAnimationDuration, _lockAnimationStrength);
        }
    }
}