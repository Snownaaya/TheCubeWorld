using Assets.Scripts.Items;
using System.Collections.Generic;
using UniRx;

namespace Assets.Scripts.Player.Inventory
{
    public interface IInventory
    {
        public Dictionary<ResourceTypes, ReactiveProperty<int>> ResourceStacks { get; }
        public void AddResource(Resource resource);
        public void UseResource(ResourceTypes resourceType);
        public bool HasResource(ResourceTypes resourceType, ReactiveProperty<int> amount);
        public void Reset();
    }
}