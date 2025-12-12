using Assets.Scripts.Service.Json;
using Newtonsoft.Json;
using System.IO;

namespace Assets.Scripts.Service.Saves
{
    public class JsonService : IJsonService
    {
        public T Deserialize<T>(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
                return default;

            return JsonConvert.DeserializeObject<T>(File.ReadAllText(json));
        }

        public string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj,
                Formatting.Indented,
                new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }
    }
}