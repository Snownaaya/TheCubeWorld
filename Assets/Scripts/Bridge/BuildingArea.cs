using System;
using UnityEngine;

public class BuildingArea : MonoBehaviour
{
    [SerializeField] private Transform _nextPositionPoint;
    
    public event Action<Resource> ResourceDelivered;

    public void DeliveResource(Resource resource) => 
        ResourceDelivered?.Invoke(resource);
    
    public void MoveBarrier() =>
        transform.position = _nextPositionPoint.position;
}
