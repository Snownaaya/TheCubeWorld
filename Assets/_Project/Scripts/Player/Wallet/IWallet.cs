namespace Assets.Scripts.Player.Wallet
{
    using Assets.Scripts.Datas.Character;

    public interface IWallet
    {
        public IPersistentCharacterData PersistentCharacterData { get; }

        public void AddCoins(int coins);

        public void RemoveCoins(int coins);

        public bool IsEnought(int coins);

        public int GetCurrentCoin();
    }
}