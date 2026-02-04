namespace Assets.Scripts.Player.Saves
{
    public interface ICharacterSaveRepository
    {
        void Save<T>(string key, T value);
        T Load<T>(string key, T defaultValue = default);
    }
}