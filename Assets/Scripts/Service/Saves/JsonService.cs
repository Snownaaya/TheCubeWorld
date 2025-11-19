using Assets.Scripts.Service.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Service.Saves
{
    public class JsonService : IJsonService
    {
        public T Deserialize<T>(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
                return default;

            try
            {
                return JsonConvert.DeserializeObject<T>(json, GetSettings());
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"{typeof(T)}: {ex.Message}", ex);
            }
        }

        public string Serialize<T>(T obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj, Formatting.Indented, GetSettings());
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"{typeof(T)}: {ex.Message}", ex);
            }
        }

        private JsonSerializerSettings GetSettings()
        {
            return new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,

                Converters = new List<JsonConverter>
                {
                    new Newtonsoft.Json.Converters.StringEnumConverter()
                }
            };
        }
    }
}