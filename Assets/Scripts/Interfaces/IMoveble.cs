using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    public interface IMoveble
    {
        public Rigidbody Player { get; }
        public Transform Transform { get; }
        public float Speed { get; }
    }
}
