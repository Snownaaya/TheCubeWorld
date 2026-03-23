namespace Assets.Scripts.UI.GameUI
{
    using Assets.Project.Scripts.UI.Shop;
    using UnityEngine;

    public class BackgroundPanel : MonoBehaviour
    {
        [SerializeField] private RectTransform _background;
        [SerializeField] private ShopInfo _foreground;

        public void Show()
        {
            if (_background == null)
                return;

            _background.gameObject.SetActive(true);
            _foreground.gameObject.SetActive(true);
        }

        public void Hide()
        {
            if (_background == null)
                return;

            _background.gameObject.SetActive(false);
            _foreground.gameObject.SetActive(false);
        }
    }
}