using Assets.Scripts.Service.Properties;
using System.Collections.Generic;
using Assets.Scripts.Items;
using UnityEngine;
using System;

namespace Assets.Scripts.Player.Inventory
{
    [Serializable]
    public class PlayerInventory : IInventory
    {
        private InventorySaver _inventorySaver;
        private Dictionary<ResourceTypes, NotLimitedProperty<int>> _resources = new Dictionary<ResourceTypes, NotLimitedProperty<int>>();

        public PlayerInventory(InventorySaver inventorySaver)
        {
            _inventorySaver = inventorySaver;
            InitializeResources();
            _resources = _inventorySaver.LoadInventory();
        }

        public IReadOnlyDictionary<ResourceTypes, NotLimitedProperty<int>> ResourceStacks => _resources;

        public void AddResource(Resource resource)
        {
            if (resource == null)
                return;

            ResourceTypes type = resource.Config.ResourceType;

            if (_resources.ContainsKey(resource.Config.ResourceType) == false)
                _resources[type] = new NotLimitedProperty<int>(0);

            _resources[type].Value += 1000; //value++
            resource.PickUp();
            _inventorySaver.SaveInventory(_resources);
            Debug.Log($"Added resource {type}, new count: {_resources[type].Value}");
        }

        public void UseResource(ResourceTypes resourceType)
        {
            if (_resources.ContainsKey(resourceType) == false)
                return;

            if (_resources.TryGetValue(resourceType, out NotLimitedProperty<int> resource) && resource.Value > 0)
            {
                resource.Value--;
                _inventorySaver.SaveInventory(_resources);
            }
        }

        public bool HasResource(ResourceTypes resourceType, NotLimitedProperty<int> amount)
        {
            if (_resources.TryGetValue(resourceType, out NotLimitedProperty<int> resource))
                return resource.Value > amount.Value;

            return false;
        }

        public void Reset() =>
            _resources.Clear();

        private void InitializeResources()
        {
            _resources = new Dictionary<ResourceTypes, NotLimitedProperty<int>>
            {
                [ResourceTypes.Dirt] = new NotLimitedProperty<int>(0),
                [ResourceTypes.Wood] = new NotLimitedProperty<int>(0),
                [ResourceTypes.Stone] = new NotLimitedProperty<int>(0)
            };
        }
    }
}