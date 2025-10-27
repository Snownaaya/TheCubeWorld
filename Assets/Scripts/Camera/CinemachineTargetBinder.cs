using Cinemachine;
using UnityEngine;

namespace Assets.Scripts.Camera
{
    public class CinemachineTargetBinder : IVirtualCamera
    {
        private CinemachineVirtualCamera _virtualCamera;

        public CinemachineTargetBinder(CinemachineVirtualCamera cinemachineVirtualCamera) =>
           _virtualCamera = cinemachineVirtualCamera;

        public void SetTarget(Transform target)
        {
            _virtualCamera.Follow = target;
            _virtualCamera.LookAt = target;
        }

        public Transform GetPosition()
        {
            return _virtualCamera.transform;
        }
    }
}