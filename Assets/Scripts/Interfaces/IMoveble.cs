using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    public interface IMoveble
    {
        public Rigidbody Rigidbody { get; }
        public float Speed { get; }
        public CharacterView CharacterView { get; }
        public PlayerInput PlayerInput { get; } 
        public Joystick Joystick { get; }
        public void Move(Vector3 direction);
        public void StopMove();
    }
}
