using UnityEngine.UI;
using UnityEngine;

namespace Assets.Scripts.UI.Shop
{
    public class SelectionImage : MonoBehaviour
    {
        [SerializeField] private Image _selectImage;
        [SerializeField] private BuyButton _buyButton;

        public void ShowSelectIamge()
        {
            _selectImage.gameObject.SetActive(true);
            _buyButton.Hide();
        }

        public void HideSelectionImage() =>
            _selectImage.gameObject.SetActive(false);
    }
}