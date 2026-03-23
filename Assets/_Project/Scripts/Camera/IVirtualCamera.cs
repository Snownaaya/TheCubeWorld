namespace Assets.Scripts.Camera
{
    using UnityEngine;

    public interface IVirtualCamera
    {
        public void SetTarget(Transform target);

        public void ResetTransform();

        public void ChangeRotate();
    }
}
