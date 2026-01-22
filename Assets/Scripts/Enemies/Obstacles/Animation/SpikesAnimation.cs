using UnityEngine;

namespace Assets.Scripts.Enemies.Obstacles.Animation
{
    [RequireComponent(typeof(Animator))]
    public class SpikesAnimation : MonoBehaviour
    {
        private const string IsStopped = nameof(IsStopped);
        private const string IsActive = nameof(IsActive);

        private Animator _animator;
        private Collider _collider;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _collider = GetComponentInChildren<Collider>();
        }

        public void Stopped()
        {
            _animator.SetBool(IsStopped, true);
            _animator.SetBool(IsActive, false);
            _collider.enabled = false;
        }
    }
}