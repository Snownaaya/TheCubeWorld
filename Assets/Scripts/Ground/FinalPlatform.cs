using Assets.Scripts.Interfaces;
using Assets.Scripts.Player;
using Assets.Scripts.Camera;
using Reflex.Attributes;
using UnityEngine;
using System;

namespace Assets.Scripts.Ground
{
    public class FinalPlatform : MonoBehaviour
    {
        [SerializeField] private Transform _cameraPoint;

        private IVirtualCamera _targetBinder;

        [Inject]
        private void Construct(IVirtualCamera targetBinder) =>
            _targetBinder = targetBinder;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out Character character))
            {
                _targetBinder.ResetTransform();
                _targetBinder.SetTarget(_cameraPoint);
                _targetBinder.ChangeRotate();
            }
        }
    }
}