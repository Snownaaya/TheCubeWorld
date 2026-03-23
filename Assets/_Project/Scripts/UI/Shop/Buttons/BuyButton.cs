namespace Assets.Scripts.UI.Shop.Buttons
{
    using System;
    using Assets.Project.Scripts.Other;
    using Assets.Scripts.UI.GameUI;
    using DG.Tweening;
    using UnityEngine;
    using UnityEngine.UI;

    public class BuyButton : UIElement
    {
        [Range(0.5f, 5)] [SerializeField] private float _lockAnimationStrength = 2f;
        [Range(0, 1)] [SerializeField]    private float _lockAnimationDuration = 0.4f;

        [SerializeField]                  private Button _buyButton;
        [SerializeField]                  private RectTransform _buyRectTransform;

        public event Action Clicked;

        private void OnEnable() =>
            _buyButton.onClick.AddListener(OnClick);

        private void OnDisable() =>
            _buyButton.onClick.RemoveListener(OnClick);

        public override void Show()
        {
            base.Show();    
            _buyButton.gameObject.SetActive(true);
        }

        public override void Hide()
        {
            base.Hide();
            _buyButton.gameObject.SetActive(false);
        }

        private void OnClick()
        {
            Clicked?.Invoke();
            TweenHelper.ButtonShake(transform);
            _buyButton.transform.DOShakePosition(_lockAnimationDuration, _lockAnimationStrength);
        }
    }
}