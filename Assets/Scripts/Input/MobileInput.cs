using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Input
{
    public class MobileInput : IInput
    {
        private PlayerInput _playerInput;
        public event Action<Vector3> Moved;
        public event Action Stopped;

        public MobileInput(PlayerInput playerInput)
        {
            _playerInput = playerInput;

            _playerInput.Character.Move.performed += context => OnMove(context);
            _playerInput.Character.Move.canceled += context => OnStop(context);
        }

        public void Dispose()
        {
            _playerInput.Character.Move.performed -= context => OnMove(context);
            _playerInput.Character.Move.canceled -= context => OnStop(context);
        }

        private void OnMove(InputAction.CallbackContext context)
        {
            Vector2 value = context.ReadValue<Vector2>();
            Vector3 direction = new Vector3(value.y, 0, -value.x);
            Moved?.Invoke(direction);
        }

        private void OnStop(InputAction.CallbackContext context) =>
            Stopped?.Invoke();

        public Vector2 Move => _playerInput.Character.Move.ReadValue<Vector2>();
    }
}
