using UnityEngine;

namespace Assets.Scripts.Enemies.Boss
{
    public class BossView : MonoBehaviour
    {
        private const string IsIdle = nameof(IsIdle);
        private const string IsAttack = nameof(IsAttack);
        private const string IsDeath = nameof(IsDeath);

        private Animator _animator;

        public void Init() =>
            _animator = GetComponent<Animator>();

        public void StartIdle() =>
            _animator.SetBool(IsIdle, true);

        public void StopIdle() =>
            _animator.SetBool(IsIdle, false);

        public void StartAttack() =>
            _animator.SetBool(IsAttack, true);

        public void StopAttack() =>
            _animator.SetBool(IsAttack, false);

        public void StartDeath() =>
            _animator.SetBool(IsDeath, true);
    }
}