using UnityEngine;

namespace Assets.Scripts.Service.Saves
{
    public class SaveService : ISaveService
    {
        public string Load(string dataKey)
        {
            if (string.IsNullOrWhiteSpace(dataKey))
                return string.Empty;

            return PlayerPrefs.GetString(dataKey, string.Empty);
        }

        public void Save(string dataKey, string data)
        {
            if (string.IsNullOrWhiteSpace(dataKey))
                return;

            PlayerPrefs.SetString(dataKey, data);
        }
    }
}