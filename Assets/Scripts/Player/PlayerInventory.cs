using Assets.Scripts.Items;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Player
{
    [Serializable]
    public class PlayerInventory
    {
        [SerializeField] private ResourceStorage _resourceStorage;

        private Dictionary<Resource, int> _resouceCount = new Dictionary<Resource, int>();

        public IReadOnlyDictionary<Resource, int> ResouceCount => _resouceCount;

        public void CollectResource(Resource resource)
        {
            if (resource == null)
                return;

            if (_resouceCount.ContainsKey(resource) == false)
                _resouceCount[resource] = 0;

            var resourceStorage = _resourceStorage.GetResourceType(resource);
            _resouceCount[resource] += resource.Amount;
            _resourceStorage.AddResource(resourceStorage);
        }

        public void UseResource(Resource resource)
        {

            if (_resouceCount.ContainsKey(resource) && _resouceCount[resource] > 0)
            {
                _resouceCount[resource] -= resource.Amount;
                _resourceStorage.RemoveCube(resource);
            }
        }

        public bool HasEnoughResource(Resource resource, int amount = 0)
        {
            if (resource == null)
                return false;

            if (ResouceCount.TryGetValue(resource, out int count))
                return count >= amount;

            return true;
        }
    }
}
