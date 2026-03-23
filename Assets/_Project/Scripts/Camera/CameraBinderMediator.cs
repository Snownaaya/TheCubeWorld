namespace Assets.Scripts.Camera
{
    using System;
    using Assets.Scripts.Player.Core;
    using Reflex.Attributes;
    using UnityEngine;

    public class CameraBinderMediator : MonoBehaviour
    {
        private IVirtualCamera _virtualCamera;
        private ICharacterHolder _characterHolder;

        [Inject]
        private void Construct(IVirtualCamera virtualCamera, ICharacterHolder characterHolder)
        {
            _virtualCamera = virtualCamera ?? throw new ArgumentNullException(nameof(virtualCamera));
            _characterHolder = characterHolder ?? throw new ArgumentNullException(nameof(characterHolder));

            _virtualCamera.SetTarget(_characterHolder.Character.transform);
        }
    }
}
