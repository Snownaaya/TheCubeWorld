using Assets.Scripts.Items;
using Assets.Scripts.Service.Properties;
using System.Collections.Generic;

namespace Assets.Scripts.Player.Inventory
{
    public interface IInventory
    {
        public IReadOnlyDictionary<ResourceTypes, NotLimitedProperty<int>> ResourceStacks { get; }
        public void AddResource(Resource resource);
        public void UseResource(ResourceTypes resourceType);
        public bool HasResource(ResourceTypes resourceType, NotLimitedProperty<int> amount);
        public void Reset();
    }
}