using Assets.Scripts.Interfaces;
using UnityEngine.InputSystem;
using UnityEngine;
using System;

namespace Assets.Scripts.Player.Input
{
    public class DesktopInput : IInput
    {
        private IMoveble _moveble;

        public DesktopInput(IMoveble moveble)
        {
            _moveble = moveble;
            _moveble.PlayerInput.Character.Move.performed += ctx => OnMove(ctx);
            _moveble.PlayerInput.Character.Move.canceled += ctx => OnMoveStop(ctx);
        }

        public event Action<Vector3> Moved;

        private void OnMove(InputAction.CallbackContext context)
        {
            Vector3 direction = new Vector3(Move.x, 0, Move.y);
            _moveble.Move(direction);
        }

        private void OnMoveStop(InputAction.CallbackContext context)
        {
            _moveble.StopMove();
        }

        public Vector2 Move => _moveble.PlayerInput.Character.Move.ReadValue<Vector2>();
    }
}
