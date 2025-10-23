using UnityEngine;

namespace Assets.Scripts.Service.Saves
{
    public class SaveService : ISaveService
    {
        public string Load(string dataKey)
        {
            if (IsDataAlreadyExist(dataKey) == false)
                return string.Empty;

            if (string.IsNullOrWhiteSpace(dataKey))
                return string.Empty;

            //PlayerPrefs.DeleteAll();

            return PlayerPrefs.GetString(dataKey, string.Empty);
        }

        public void Save(string dataKey, string data)
        {
            if (string.IsNullOrWhiteSpace(dataKey))
                return;

            PlayerPrefs.SetString(dataKey, data);
        }

        private bool IsDataAlreadyExist(string dataKey) =>
            PlayerPrefs.HasKey(dataKey);
    }
}