namespace Assets.Scripts.UI.Shop
{
    using Assets.Scripts.UI.GameUI;
    using UnityEngine;
    using UnityEngine.UI;

    public class OwnedImage : UIElement
    {
        [SerializeField] private Image _selectImage;

        public override void Show() =>
            _selectImage.gameObject.SetActive(true);

        public override void Hide() =>
            _selectImage.gameObject.SetActive(false);
    }
}