using Assets.Scripts.Datas;
using System;

namespace Assets.Scripts.Player.Wallet
{
    public interface IWallet
    {
        public CharacterData CharacterData { get; }
        public void AddCoins(int coins);
        public void RemoveCoins(int coins);
        public bool IsEnought(int coins);
        public int GetCurrentCoin();
    }
}