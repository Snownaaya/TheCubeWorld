using Cinemachine;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
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

        public void ResetTransform()
        {
            _virtualCamera.Follow = null;
            _virtualCamera.LookAt = null;
        }

        public void ChangeRotate()
        {
            Vector3 rotation = new Vector3(13f, 130f, 0);
            _virtualCamera.transform.eulerAngles = rotation;
        }
    }
}