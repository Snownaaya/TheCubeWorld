using Assets.Scripts.Player.Core;
using Reflex.Attributes;
using System;
using UnityEngine;

namespace Assets.Scripts.Camera
{
    public class CameraBinderMediator : MonoBehaviour
    {
        private IVirtualCamera _virtualCamera;
        private CharacterHolder _characterHolder;

        [Inject]
        private void Construct(IVirtualCamera virtualCamera, CharacterHolder characterHolder)
        {
            _virtualCamera = virtualCamera ?? throw new ArgumentNullException(nameof(virtualCamera));
            _characterHolder = characterHolder ?? throw new ArgumentNullException(nameof(characterHolder));

            _virtualCamera.SetTarget(_characterHolder.Character.transform);
        }
    }
}
