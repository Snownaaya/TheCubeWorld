using System;
using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.Interfaces;

namespace Assets.Scripts.Items
{
    public class ResourceStorage : MonoBehaviour, IResourceStorage
    {
        private Dictionary<ResourceType, Queue<Resource>> _cubes = new Dictionary<ResourceType, Queue<Resource>>();

        public void AddResource(Resource resource)
        {
            if (resource == null)
                return;

            if (_cubes.TryGetValue(resource.ResourceType, out Queue<Resource> resources))
            {
                resources.Enqueue(resource);
            }
            else
            {
                resources = new Queue<Resource>();
                resources.Enqueue(resource);
                _cubes.Add(resource.ResourceType, resources);
            }
        }

        public void RemoveResource(ResourceType resourceType, int amount)
        {
            if (_cubes.TryGetValue(resourceType, out Queue<Resource> resources))
            {
                if (resources.Count >= amount)
                {
                    for (int i = 0; i < amount; i++)
                        resources.Dequeue();
                }
            }
        }

        public Resource GetResource(ResourceType resourceType)
        {
            if (_cubes.TryGetValue(resourceType, out Queue<Resource> resources) && resources.Count > 0)
                return resources.Peek();

            return null;
        }
    }
}