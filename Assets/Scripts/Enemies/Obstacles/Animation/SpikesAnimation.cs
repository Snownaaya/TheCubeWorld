using UnityEngine;

namespace Assets.Scripts.Enemies.Obstacles.Animation
{
    [RequireComponent(typeof(Animator))]
    public class SpikesAnimation : MonoBehaviour
    {
        private const string IsStopped = nameof(IsStopped);
        private const string IsActive = nameof(IsActive); 

        public Animator _animator;

        private void Awake() =>
            _animator = GetComponent<Animator>();

        public void Stopped()
        {
            _animator.SetBool(IsStopped, true);
            _animator.SetBool(IsActive, false);
        }
    }
}