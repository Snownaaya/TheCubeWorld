using Assets.Scripts.UI.GameUI;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Shop.Buttons
{
    public class SelectionButton : UIElement
    {
        [SerializeField] private Button _select;

        public event Action Clicked;

        private void OnEnable() =>
            _select.onClick.AddListener(OnSelectionButtonClick);

        private void OnDisable() =>
            _select.onClick.RemoveListener(OnSelectionButtonClick);

        public override void Show() =>
            _select.gameObject.SetActive(true);

        public override void Hide() =>
            _select.gameObject.SetActive(false);

        private void OnSelectionButtonClick() =>
            Clicked?.Invoke();
    }
}