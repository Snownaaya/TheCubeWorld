using Assets.Scripts.Datas;
using UnityEngine;
using System;

namespace Assets.Scripts.Bridge
{
    public class BuildingArea : MonoBehaviour
    {
        [SerializeField] private Transform _nextPositionPoint;

        public event Action<ResourceConfig> ResourceDelivered;

        public void DeliveResource(ResourceConfig resource) =>
            ResourceDelivered?.Invoke(resource);

        public void MoveBarrier() =>
            transform.position = _nextPositionPoint.position;
    }
}