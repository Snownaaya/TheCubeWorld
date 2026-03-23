namespace Assets.Project.Scripts.UI.Shop
{
    using Assets.Scripts.UI.GameUI;
    using UnityEngine;

    public class TogglePrice : UIElement
    {
        [SerializeField] private RectTransform _rectTransform;

        public override void Show() =>
            _rectTransform.gameObject.SetActive(true);

        public override void Hide() =>
            _rectTransform.gameObject.SetActive(false);
    }
}