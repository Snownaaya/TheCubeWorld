using Cinemachine;
using UnityEngine;

namespace Assets.Scripts.Camera
{
    public interface IVirtualCamera
    {
        public void SetTarget(Transform target);
        public void ResetTransform();
        public void ChangeRotate();
    }
}
