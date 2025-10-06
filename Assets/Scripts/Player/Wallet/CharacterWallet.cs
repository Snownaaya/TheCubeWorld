using Assets.Scripts.Datas;
using System;

namespace Assets.Scripts.Player.Wallet
{
    public class CharacterWallet : IWallet
    {
        private CharacterData _characterData;
        private WalletSaver _walletSaver;

        public CharacterWallet(CharacterData characterData, WalletSaver walletSaver)
        {
            _characterData = characterData;
            _walletSaver = walletSaver;
            _walletSaver.Load();
        }

        public event Action CoinsChanged;

        public void AddCoins(int coins)
        {
            _characterData.Money.Value += coins;
            _walletSaver.Save(_characterData.Money.Value);
            CoinsChanged?.Invoke();
        }

        public void RemoveCoins(int coins)
        {
            _characterData.Money.Value -= coins;
            _walletSaver.Save(_characterData.Money.Value);
            CoinsChanged?.Invoke();
        }

        public bool IsEnought(int coins)
        {
            if (coins < 0)
                throw new ArgumentOutOfRangeException(nameof(coins));

            if (_characterData.Money.Value <= 0)
                return false;

            return _characterData.Money.Value >= coins;
        }
    }
}