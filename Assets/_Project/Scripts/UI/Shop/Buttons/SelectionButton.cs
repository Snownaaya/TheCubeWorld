namespace Assets.Scripts.UI.Shop.Buttons
{
    using System;
    using Assets.Scripts.UI.GameUI;
    using UnityEngine;
    using UnityEngine.UI;

    public class SelectionButton : UIElement
    {
        [SerializeField] private Button _select;

        public event Action Clicked;

        private void OnEnable() =>
            _select.onClick.AddListener(OnSelectionButtonClick);

        private void OnDisable() =>
            _select.onClick.RemoveListener(OnSelectionButtonClick);

        public override void Show()
        {
            base.Show();
            _select.gameObject.SetActive(true);
        }

        public override void Hide()
        {
            base.Hide();
            _select.gameObject.SetActive(false);
        }

        private void OnSelectionButtonClick() =>
            Clicked?.Invoke();
    }
}