using Assets.Scripts.Interfaces;
using Reflex.Attributes;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Player.Input
{
    public class MobileInput
    {
        private IMoveble _moveble;

        [Inject]
        private void Construct(IMoveble moveble)
        {
            _moveble = moveble;
        }

        public InputAction Move => _moveble.PlayerInput.Character.Move;
    }
}
