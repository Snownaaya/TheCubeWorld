using Assets.Scripts.UI.GameUI;
using UnityEngine;

namespace Assets.Scripts.UI.MainMenu
{
    public class ShopButton : WindowView
    {
        [SerializeField] private BackgroundPanel _backgroundPanel;
        [SerializeField] private ShopPanel _shopPanel;

        protected override void Close()
        {
            _backgroundPanel.Hide();
            _shopPanel.gameObject.SetActive(false);
        }

        protected override void Open()
        {
            _shopPanel.gameObject.SetActive(true);
            _backgroundPanel.Show();
        }
    }
}