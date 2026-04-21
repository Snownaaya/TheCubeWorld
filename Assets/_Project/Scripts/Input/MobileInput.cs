using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Input
{
    public class MobileInput : IInput
    {
        private PlayerInput _playerInput;
        private IJoystickInput _joystickInput;

        public event Action<Vector3> Moved;

        public event Action Stopped;

        public MobileInput(
            PlayerInput playerInput,
            IJoystickInput joystickInput)
        {
            _playerInput = playerInput;
            _joystickInput = joystickInput;
            _joystickInput.SetInteractable(true);

            _playerInput.Character.Move.performed += context => OnMove(context);
            _playerInput.Character.Move.canceled += context => OnStop(context);
        }

        public Vector2 Move => _playerInput.Character.Move.ReadValue<Vector2>();

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
    }
}
