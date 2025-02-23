using System;
using System.Collections.Generic;
using Assets.Scripts.Items;

namespace Assets.Scripts.Player
{
    [Serializable]
    public class PlayerInventory
    {
        private Dictionary<ResourceType, Stack<ResourceData>> _resourceStacks = new Dictionary<ResourceType, Stack<ResourceData>>();

        public IReadOnlyDictionary<ResourceType, Stack<ResourceData>> ResourceStacks => _resourceStacks;

        public void CollectResource(Resource resource)
        {
            if (resource == null)
                return;

            ResourceType type = resource.ResourceType;

            if (!_resourceStacks.ContainsKey(type))
                _resourceStacks[type] = new Stack<ResourceData>();

            if (_resourceStacks[type].Count > 0 && _resourceStacks[type].Peek().Type == type)
            {
                ResourceData topResource = _resourceStacks[type].Pop();
                topResource.Amount += 1;
                _resourceStacks[type].Push(topResource);
            }
            else
            {
                _resourceStacks[type].Push(new ResourceData(type, 1));
            }

            resource.PickUp();
        }

        public bool UseResource(ResourceType type)
        {
            if (_resourceStacks.TryGetValue(type, out Stack<ResourceData> stack) && stack.Count > 0)
            {
                ResourceData topResource = stack.Pop();
                if (topResource.Amount > 1)
                {
                    topResource.Amount -= 1;
                    stack.Push(topResource);
                }
                return true;
            }
            return false;
        }

        public bool HasEnoughResource(ResourceType type, int amount)
        {
            if (_resourceStacks.TryGetValue(type, out Stack<ResourceData> stack))
            {
                int totalAmount = 0;
                foreach (var resource in stack)
                    totalAmount += resource.Amount;

                return totalAmount >= amount;
            }
            return false;
        }
    }

    [Serializable]
    public struct ResourceData
    {
        public ResourceType Type;
        public int Amount;

        public ResourceData(ResourceType type, int amount)
        {
            Type = type;
            Amount = amount;
        }
    }
}
