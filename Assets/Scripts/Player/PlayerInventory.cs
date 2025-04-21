using System;
using Assets.Scripts.Items;
using Assets.Scripts.Utils;
using System.Collections.Generic;

namespace Assets.Scripts.Player
{
    [Serializable]
    public class PlayerInventory
    {
        private Dictionary<ResourceType, NotLessZeroProperty<int>> _resources = new Dictionary<ResourceType, NotLessZeroProperty<int>>();

        public PlayerInventory()
        {
            _resources[ResourceType.Dirt] = new NotLessZeroProperty<int>(0);
            _resources[ResourceType.Wood] = new NotLessZeroProperty<int>(0);
            _resources[ResourceType.Stone] = new NotLessZeroProperty<int>(0);
        }

        public IReadOnlyDictionary<ResourceType, NotLessZeroProperty<int>> ResourceStacks => _resources;

        public void AddResource(Resource resource)
        {
            if(resource == null) 
             return;

            ResourceType type = resource.ResourceType;

            if (_resources.ContainsKey(resource.ResourceType) == false)
                _resources[type] = new NotLessZeroProperty<int>(0);

            _resources[type].Value++;
            resource.PickUp();
        }

        public void UseResource(ResourceType resourceType)
        {
            if(_resources.ContainsKey(resourceType) == false) 
                return;

            if(_resources.TryGetValue(resourceType, out NotLessZeroProperty<int> resource) && resource.Value > 0)
                resource.Value--;
        }

        public bool HasResource(ResourceType resourceType, int amount = 0)
        {
            if (_resources.TryGetValue(resourceType, out NotLessZeroProperty<int> resource))
                return resource.Value >= amount;

            return false;
        }
    }
}