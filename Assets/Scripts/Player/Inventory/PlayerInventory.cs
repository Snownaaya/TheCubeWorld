using Assets.Scripts.Items;
using System;
using System.Collections.Generic;
using UniRx;

namespace Assets.Scripts.Player.Inventory
{
    [Serializable]
    public class PlayerInventory : IInventory
    {
        private Dictionary<ResourceTypes, ReactiveProperty<int>> _resources = new Dictionary<ResourceTypes, ReactiveProperty<int>>();

        public PlayerInventory() =>
            InitializeResources();

        public Dictionary<ResourceTypes, ReactiveProperty<int>> ResourceStacks => _resources;

        public void AddResource(Resource resource)
        {
            if (resource == null)
                return;

            ResourceTypes type = resource.Config.ResourceType;

            if (_resources.ContainsKey(resource.Config.ResourceType) == false)
                _resources[type] = new ReactiveProperty<int>(0);

            _resources[type].Value++;
        }

        public void UseResource(ResourceTypes resourceType)
        {
            if (_resources.ContainsKey(resourceType) == false)
                return;

            if (_resources.TryGetValue(resourceType, out ReactiveProperty<int> resource) && resource.Value > 0)
                resource.Value--;
        }

        public bool HasResource(ResourceTypes resourceType, ReactiveProperty<int> amount)
        {
            if (_resources.TryGetValue(resourceType, out ReactiveProperty<int> resource))
                return resource.Value > amount.Value;

            return false;
        }

        public void Reset()
        {
            foreach (var resource in _resources)
                resource.Value.Value = 0;
        }

        public int GetTotalResourcesAmount()
        {
            int total = 0;

            foreach (var pair in _resources)
                total += pair.Value.Value;

            return total;
        }

        private void InitializeResources()
        {
            _resources = new Dictionary<ResourceTypes, ReactiveProperty<int>>
            {
                [ResourceTypes.Dirt] = new ReactiveProperty<int>(0),
                [ResourceTypes.Wood] = new ReactiveProperty<int>(0),
                [ResourceTypes.Stone] = new ReactiveProperty<int>(0)
            };
        }
    }
}