namespace Assets.Scripts.Bridge
{
    using System;
    using Assets.Scripts.Datas;
    using UnityEngine;

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