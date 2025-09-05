using Assets.Scripts.Interfaces;
using Assets.Scripts.Loss;
using UnityEngine;
using System;

namespace Assets.Scripts.Player
{
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
}