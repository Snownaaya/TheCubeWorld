using UnityEngine;

namespace Assets.Scripts.Service.Saves
{
    public class SaveService : ISaveService
    {
        public string Load(string dataKey)
        {
            if (string.IsNullOrWhiteSpace(dataKey) || !PlayerPrefs.HasKey(dataKey))
                return string.Empty;

            string data = PlayerPrefs.GetString(dataKey, string.Empty);

            PlayerPrefs.DeleteAll();

            return string.IsNullOrWhiteSpace(data) ? string.Empty : data;
        }

        public void Save(string dataKey, string data)
        {
            if (string.IsNullOrWhiteSpace(dataKey))
                return;

            PlayerPrefs.SetString(dataKey, data);
            PlayerPrefs.Save();
        }
    }
}