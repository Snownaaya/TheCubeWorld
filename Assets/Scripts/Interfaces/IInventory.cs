using Assets.Scripts.Items;
using Assets.Scripts.Utils;
using System.Collections.Generic;

namespace Assets.Scripts.Interfaces
{
    public interface IInventory
    {
        public IReadOnlyDictionary<ResourceType, NotLessZeroProperty<int>> ResourceStacks { get; }

        public void AddResource(Resource resource);

        public void UseResource(ResourceType resourceType);

        public bool HasResource(ResourceType resourceType, NotLessZeroProperty<int> amount);
    }
}
