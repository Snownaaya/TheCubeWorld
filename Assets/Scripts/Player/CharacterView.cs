using Assets.Scripts.Datas;
using Assets.Scripts.Enemies.Boss;
using Assets.Scripts.Particles;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class CharacterView : MonoBehaviour
    {
        private const string IsIdling = nameof(IsIdling);
        private const string IsWalking = nameof(IsWalking);
        private const string IsMovement = nameof(IsMovement);
        private const string IsAttack = nameof(IsAttack);
        private const string AttackState = nameof(AttackState);

        [SerializeField] private ParticleSpawner _effects;

        private Animator _animator;
        private IBossTargetService _bossTargetService;

        private void Construct(IBossTargetService bossTargetService) =>
            _bossTargetService = bossTargetService;

        public void Initialize()
        {
            _animator = GetComponent<Animator>();
            IBossTarget bossTarget = _bossTargetService.GetCurrentBoss();
            _effects.Initialize(bossTarget.GetTargetTransform());
        }

        public void StartIdle() =>
            _animator?.SetBool(IsIdling, true);

        public void StopIdle() =>
            _animator?.SetBool(IsIdling, false);

        public void StartWalk() =>
            _animator?.SetBool(IsWalking, true);

        public void StartMovement() =>
            _animator?.SetBool(IsMovement, true);

        public void StartAttackState() =>
            _animator?.SetBool(AttackState, true);

        public void StopMovement() =>
            _animator?.SetBool(IsMovement, false);

        public void StopWalk() =>
            _animator?.SetBool(IsWalking, false);

        public void StartAttack()
        {
            IBossTarget bossTarget = _bossTargetService?.GetCurrentBoss();
            _effects.SpawnParticle(ParticleTypes.CharacterAttack, bossTarget.GetTargetTransform());
            _animator?.SetBool(IsAttack, true);
        }

        public void StopAttack()
        {
            //_effects.ReturnParticle();
            _animator?.SetBool(IsAttack, false);
        }
    }
}
