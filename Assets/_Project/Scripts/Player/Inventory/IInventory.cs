namespace Assets.Scripts.Player.Inventory
{
    using System.Collections.Generic;
    using Assets.Scripts.Items;
    using UniRx;

    public interface IInventory
    {
        public Dictionary<ResourceTypes, ReactiveProperty<int>> ResourceStacks { get; }

        public void AddResource(Resource resource);

        public void UseResource(ResourceTypes resourceType);

        public bool HasResource(ResourceTypes resourceType, int amount);

        public int GetTotalResourcesAmount();

        public void Reset();
    }
}