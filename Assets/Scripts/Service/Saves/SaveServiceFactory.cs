using Assets.Scripts.Service.Json;

namespace Assets.Scripts.Service .Saves
{
    public class SaveServiceFactory
    {
        public ISaveService CreateSaveService() =>
            new SaveService();

        public IJsonService CreateJsonService() =>
            new JsonService();
    }
}
