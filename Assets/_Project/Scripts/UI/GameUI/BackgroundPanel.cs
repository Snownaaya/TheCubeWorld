namespace Assets.Scripts.UI.GameUI
{
    using Assets.Project.Scripts.UI.Shop;
    using UnityEngine;

    public class BackgroundPanel : MonoBehaviour
    {
        [SerializeField] private RectTransform _background;

        public void Show()
        {
            if (_background == null)
                return;

            _background.gameObject.SetActive(true);
        }

        public void Hide()
        {
            if (_background == null)
                return;

            _background.gameObject.SetActive(false);
        }
    }
}