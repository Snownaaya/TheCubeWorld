using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    public interface IMoveble
    {
        public Rigidbody Rigidbody { get; }
        public float Speed { get; }
        public CharacterView CharacterView { get; }
    }
}
