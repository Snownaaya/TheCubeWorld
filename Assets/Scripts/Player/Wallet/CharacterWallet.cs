using Assets.Scripts.Datas;
using Assets.Scripts.Service.Properties;
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

            NotLessZeroProperty<int> loadMoney = _walletSaver.Load();
            _characterData.SetMoney(loadMoney.Value);
        }
        public CharacterData CharacterData => _characterData;

        public void AddCoins(int coins)
        {
            _characterData.Money.Value += coins;
            _walletSaver.Save(_characterData.Money);
            UnityEngine.Debug.Log(coins);
        }

        public void RemoveCoins(int coins)
        {
            _characterData.Money.Value -= coins;
            _walletSaver.Save(_characterData.Money);
        }

        public bool IsEnought(int coins)
        {
            if (coins < 0)
                throw new ArgumentOutOfRangeException(nameof(coins));

            if (_characterData.Money.Value <= 0)
                return false;

            return _characterData.Money.Value >= coins;
        }

        public int GetCurrentCoin() =>
            _characterData.Money.Value;
    }
}