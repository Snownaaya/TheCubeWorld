using System;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

namespace Assets.Scripts.Items
{
    public class ResourceStorage : MonoBehaviour
    {
        private Dictionary<Type, Queue<Resource>> _cubes = new Dictionary<Type, Queue<Resource>>();

        public IReadOnlyDictionary<Type, Queue<Resource>> Cubes => _cubes;

        public void AddResource(Resource resource)
        {
            if (resource == null)
                return;

            if (_cubes.TryGetValue(resource.GetType(), out Queue<Resource> resources))
            {
                resources.Enqueue(resource);
            }
            else
            {
                resources = new Queue<Resource>();
                resources.Enqueue(resource);
                _cubes.Add(resource.GetType(), resources);
            }
        }

        public void RemoveResource(Resource resource)
        {
            if (_cubes.TryGetValue(resource.GetType(), out Queue<Resource> resources))
            {
                Queue<Resource> newQueue = new Queue<Resource>(resources.Where(r => r != resource));
                _cubes[resource.GetType()] = newQueue;
            }
        }
    }
}