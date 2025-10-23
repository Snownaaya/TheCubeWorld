using Assets.Scripts.Interfaces;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.UI.SelectButtons
{
    public class BridgeSelectionButton : MonoBehaviour, IButtonWidget
    {
        [SerializeField] private Button _selectionButton;
        [SerializeField] private BridgeChoicePanel _bridgePanel;

        private void OnEnable() =>
            _selectionButton.onClick.AddListener(TogglePanel);

        private void OnDisable() =>
            _selectionButton.onClick.RemoveListener(TogglePanel);

        private void TogglePanel()
        {
            if (_bridgePanel.IsOpen == false)
                _bridgePanel.Open();
            else
                _bridgePanel.Close();
        }

        public void OnPointerDown(PointerEventData eventData) =>
            AnimatePress();

        public void OnPointerUp(PointerEventData eventData) =>
            AnimateRelease();

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