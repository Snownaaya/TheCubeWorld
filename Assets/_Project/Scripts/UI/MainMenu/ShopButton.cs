namespace Assets.Scripts.UI.MainMenu
{
    using Assets.Scripts.Player.Wallet;
    using Assets.Scripts.UI.GameUI;
    using Assets.Scripts.UI.Shop;
    using UnityEngine;

    public class ShopButton : WindowView
    {
        [SerializeField] private BackgroundPanel _backgroundPanel;
        [SerializeField] private BaseShopPanel _shopPanel;
        [SerializeField] private WalletView _walletView;

        protected override void Close()
        {
            base.Close();

            _backgroundPanel.Hide();
            _walletView.Hide();
            _shopPanel.gameObject.SetActive(false);
            RectTransform.gameObject.SetActive(false);
        }

        protected override void Open()
        {
            base.Open();

            _shopPanel.gameObject.SetActive(true);
            RectTransform.gameObject.SetActive(true);
            _walletView.Show();
            _backgroundPanel.Show();
        }
    }
}