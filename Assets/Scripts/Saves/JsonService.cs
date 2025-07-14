using Assets.Scripts.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Saves
{
    public class JsonService : IJsonService
    {
        public T Deserialize<T>(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
                return default;

            try
            {
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    Converters = new List<JsonConverter> { new Newtonsoft.Json.Converters.StringEnumConverter() }
                };

                return JsonConvert.DeserializeObject<T>(json, settings);
            }
            catch (Exception ex)
            {
                UnityEngine.Debug.LogError($"Ошибка десериализации JSON: {ex.Message}");
                return default;
            }
        }

        public string Serialize<T>(T t)
        {
            try
            {
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    Converters = new List<JsonConverter> { new Newtonsoft.Json.Converters.StringEnumConverter() }
                };

                return JsonConvert.SerializeObject(t, Formatting.Indented, settings);
            }
            catch (Exception ex)
            {
                UnityEngine.Debug.LogError($"Ошибка сериализации в JSON: {ex.Message}");
                return string.Empty;
            }
        }
    }
}
