using Cinemachine;
using Cysharp.Threading.Tasks;
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
            Vector3 rotation = new Vector3(13f, 120f, 0);
            _virtualCamera.transform.eulerAngles = rotation;
            RotateTarget().Forget();
        }
        
        private async UniTask RotateTarget()
        {
            await UniTask.Delay(3000);
        }
    }
}