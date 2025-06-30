using UnityEngine;
using Assets.Scripts.Interfaces;
using System;
using Assets.Scripts.Loss;

[RequireComponent(typeof(Rigidbody))]
public class CollisionHandler : MonoBehaviour
{
    public event Action<ILoss> Died;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out LossCollision loss))
            Died?.Invoke(loss);
    }
}