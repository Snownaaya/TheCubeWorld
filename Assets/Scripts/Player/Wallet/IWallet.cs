namespace Assets.Scripts.Player.Wallet
{
    public interface IWallet
    {
        public void AddCoins(int coins);
        public void RemoveCoins(int coins);
        public bool IsEnought(int coins);
    }
}
