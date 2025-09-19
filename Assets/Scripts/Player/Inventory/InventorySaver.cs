using Assets.Scripts.Service.Properties;
using System.Collections.Generic;
using Assets.Scripts.Items;
using UnityEngine;
using Assets.Scripts.Service.Saves;
using Assets.Scripts.Service.Json;

namespace Assets.Scripts.Player.Inventory
{
    public class InventorySaver
    {
        private const string INVENTORY_KEY = "PlayerInventory";

        private IJsonService _jsonService;
        private ISaveService _saveService;

        public InventorySaver(IJsonService jsonService, ISaveService saveService)
        {
            _jsonService = jsonService;
            _saveService = saveService;
        }

        public void SaveInventory(Dictionary<ResourceTypes, NotLimitedProperty<int>> resources)
        {
            string json = _jsonService.Serialize(resources);
            Debug.Log($"Saving inventory: {json}");
            _saveService.Save(INVENTORY_KEY, json);
        }

        public Dictionary<ResourceTypes, NotLimitedProperty<int>> LoadInventory()
        {
            string json = _saveService.Load(INVENTORY_KEY);
            Debug.Log($"Loaded achievements JSON: {json}");

            if (string.IsNullOrWhiteSpace(json))
                return new Dictionary<ResourceTypes, NotLimitedProperty<int>>();

            return _jsonService.Deserialize<Dictionary<ResourceTypes, NotLimitedProperty<int>>>(json);
        }
    }
}
