using Assets.Scripts.Player.Wallet;
using Assets.Scripts.UI.GameUI;
using UnityEngine;

namespace Assets.Scripts.UI.MainMenu
{
    public class ShopButton : WindowView
    {
        [SerializeField] private BackgroundPanel _backgroundPanel;
        [SerializeField] private ShopPanel _shopPanel;
        [SerializeField] private RectTransform _buttons;
        [SerializeField] private WalletView _walletView;

        protected override void Close()
        {
            base.Close();

            _backgroundPanel.Hide();
            _walletView.Hide();
            _shopPanel.gameObject.SetActive(false);
            _buttons.gameObject.SetActive(false);
        }

        protected override void Open()
        {
            base.Open();

            _shopPanel.gameObject.SetActive(true);
            _buttons.gameObject.SetActive(true);
            _walletView.Show();
            _backgroundPanel.Show();
        }
    }
}