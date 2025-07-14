using Assets.Scripts.Items;
using Assets.Scripts.Utils;
using System.Collections.Generic;

namespace Assets.Scripts.Interfaces
{
    public interface IInventory
    {
        public IReadOnlyDictionary<ResourceTypes, NotLessZeroProperty<int>> ResourceStacks { get; }

        public void AddResource(Resource resource);

        public void UseResource(ResourceTypes resourceType);

        public bool HasResource(ResourceTypes resourceType, NotLessZeroProperty<int> amount);
    }
}
