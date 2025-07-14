using System;
using Assets.Scripts.Items;
using Assets.Scripts.Utils;
using System.Collections.Generic;
using Assets.Scripts.Interfaces;

namespace Assets.Scripts.Player
{
    [Serializable]
    public class PlayerInventory : IInventory
    {
        private Dictionary<ResourceTypes, NotLessZeroProperty<int>> _resources = new Dictionary<ResourceTypes, NotLessZeroProperty<int>>();

        public PlayerInventory()
        {
            _resources[ResourceTypes.Dirt] = new NotLessZeroProperty<int>(0);
            _resources[ResourceTypes.Wood] = new NotLessZeroProperty<int>(0);
            _resources[ResourceTypes.Stone] = new NotLessZeroProperty<int>(0);
        }

        public IReadOnlyDictionary<ResourceTypes, NotLessZeroProperty<int>> ResourceStacks => _resources;

        public void AddResource(Resource resource)
        {
            if(resource == null) 
             return;

            ResourceTypes type = resource.ResourceType;

            if (_resources.ContainsKey(resource.ResourceType) == false)
                _resources[type] = new NotLessZeroProperty<int>(1);

            _resources[type].Value++;
            resource.PickUp();
        }

        public void UseResource(ResourceTypes resourceType)
        {
            if(_resources.ContainsKey(resourceType) == false) 
                return;

            if(_resources.TryGetValue(resourceType, out NotLessZeroProperty<int> resource) && resource.Value > 0)
                resource.Value--;
        }

        public bool HasResource(ResourceTypes resourceType, NotLessZeroProperty<int> amount)
        {
            if (_resources.TryGetValue(resourceType, out NotLessZeroProperty<int> resource))
                return resource.Value > amount.Value;

            return false;
        }
    }
}