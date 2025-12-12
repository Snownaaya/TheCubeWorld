using Assets.Scripts.Datas.Character;
using System;
using UniRx;

namespace Assets.Scripts.Player.Wallet
{
    public class CharacterWallet : IWallet
    {
        private IPersistentCharacterData _persistentCharacterData;

        public CharacterWallet(IPersistentCharacterData characterData)
        {
            _persistentCharacterData = characterData;
            _persistentCharacterData.Money.Value = 10000;
        }

        public IPersistentCharacterData PersistentCharacterData => _persistentCharacterData;

        public void AddCoins(int coins)
        {
            _persistentCharacterData.Money.Value += coins;
            UnityEngine.Debug.Log(coins);
        }

        public void RemoveCoins(int coins)
        {
            _persistentCharacterData.Money.Value -= coins;
        }

        public bool IsEnought(int coins)
        {
            if (coins < 0)
                throw new ArgumentOutOfRangeException(nameof(coins));

            if (_persistentCharacterData.Money.Value <= 0)
                return false;

            return _persistentCharacterData.Money.Value >= coins;
        }

        public int GetCurrentCoin() =>
            _persistentCharacterData.Money.Value;
    }
}