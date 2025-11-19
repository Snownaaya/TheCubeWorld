using UnityEngine.UI;
using UnityEngine;

namespace Assets.Scripts.UI.Shop
{
    public class OwnedImage : MonoBehaviour
    {
        [SerializeField] private Image _selectImage;

        public void Show() =>
            _selectImage.gameObject.SetActive(true);

        public void Hide() =>
            _selectImage.gameObject.SetActive(false);
    }
}