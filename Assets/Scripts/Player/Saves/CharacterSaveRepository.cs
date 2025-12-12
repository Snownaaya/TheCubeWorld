using Assets.Scripts.Service.Json;
using Assets.Scripts.Service.Saves;

namespace Assets.Scripts.Player.Saves
{
    public class CharacterSaveRepository : ICharacterSaveRepository
    {
        private readonly IJsonService _json;
        private readonly ISaveService _save;

        public CharacterSaveRepository(IJsonService json, ISaveService save)
        {
            _json = json;
            _save = save;
        }

        public void Save<T>(string key, T value)
        {
            string json = _json.Serialize(value);
            _save.Save(key, json);
        }

        public T Load<T>(string key, T defaultValue = default)
        {
            string json = _save.Load(key);
            if (string.IsNullOrEmpty(json))
                return defaultValue;

            return _json.Deserialize<T>(json);
        }
    }
}