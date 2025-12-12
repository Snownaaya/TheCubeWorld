using UnityEngine.UI;
using UnityEngine;
using Assets.Scripts.UI.GameUI;

namespace Assets.Scripts.UI.Shop
{
    public class OwnedImage : UIElement
    {
        [SerializeField] private Image _selectImage;

        public override void Show() =>
            _selectImage.gameObject.SetActive(true);

        public override void Hide() =>
            _selectImage.gameObject.SetActive(false);
    }
}