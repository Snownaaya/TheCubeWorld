using Assets.Scripts.Enemies.Boss.Target;
using Assets.Scripts.Particles;
using Reflex.Attributes;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class CharacterView : MonoBehaviour
    {
        private const string IsIdling = nameof(IsIdling);
        private const string IsWalking = nameof(IsWalking);
        private const string IsAttack = nameof(IsAttack);

        private Animator _animator;
        private IBossTargetService _bossTargetService;
        private IParticleSpawner _particleSpawner;

        [Inject]
        private void Construct(IBossTargetService bossTargetService,
            IParticleSpawner particleSpawner)
        {
            _bossTargetService = bossTargetService;
            _particleSpawner = particleSpawner;
        }

        public void Initialize() =>
            _animator = GetComponent<Animator>();

        public void StartIdle() =>
            _animator?.SetBool(IsIdling, true);

        public void StopIdle() =>
            _animator?.SetBool(IsIdling, false);

        public void StartWalk() =>
            _animator?.SetBool(IsWalking, true);

        public void StopWalk() =>
            _animator?.SetBool(IsWalking, false);

        public void StartAttack()
        {
            IBossTarget currentBoss = _bossTargetService?.GetCurrentBoss();
            _particleSpawner.SpawnParticle(ParticleTypes.CharacterAttack, currentBoss.GetTarget());
            _animator.SetBool(IsAttack, true);
        }

        public void StopAttack()
        {
            //_particleSpawner.ReturnParticle(gameObject);
            _animator?.SetBool(IsAttack, false);
        }
    }
}
