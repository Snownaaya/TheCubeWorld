using Assets.Scripts.UI.GameUI;
using UnityEngine;

namespace Assets._Project.Scripts.UI.Shop
{
    public class TogglePrice : UIElement
    {
        [SerializeField] private RectTransform _rectTransform;

        public override void Show() =>
            _rectTransform.gameObject.SetActive(true);

        public override void Hide() =>
            _rectTransform.gameObject.SetActive(false);
    }
}