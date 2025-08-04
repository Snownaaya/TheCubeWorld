using Assets.Scripts.Json;

namespace Assets.Scripts.Saves
{
    public class SaveServiceFactory
    {
        public ISaveService CreateSaveService() =>
            new SaveService();

        public IJsonService CreateJsonService() =>
            new JsonService();
    }
}
