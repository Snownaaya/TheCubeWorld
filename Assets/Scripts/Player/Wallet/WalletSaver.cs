using Assets.Scripts.Service.Json;
using Assets.Scripts.Service.Properties;
using Assets.Scripts.Service.Saves;

namespace Assets.Scripts.Player.Wallet
{
    public class WalletSaver
    {
        private const string Wallet_Key = nameof(Wallet_Key);

        private IJsonService _jsonService;
        private ISaveService _saveService;

        public WalletSaver(IJsonService jsonService, ISaveService saveService)
        {
            _jsonService = jsonService;
            _saveService = saveService;
        }

        public void Save(int coins)
        {
           string json = _jsonService.Serialize(coins);
            _saveService.Save(Wallet_Key, json);
        }

        public NotLessZeroProperty<int> Load()
        {
            string json = _saveService.Load(Wallet_Key);

            if (string.IsNullOrEmpty(json))
                return new NotLessZeroProperty<int>(0);

            return _jsonService.Deserialize<NotLessZeroProperty<int>>(json);
        }
    }
}