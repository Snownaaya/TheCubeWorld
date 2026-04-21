namespace Assets.Scripts.Player.Attack
{
    using System;
    using System.Threading;
    using Assets.Scripts.Datas.Character;
    using Assets.Scripts.UI.HealthCharacters.Characters;
    using Cysharp.Threading.Tasks;
    using UnityEngine;

    public class CharacterAttacker : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private ResourceConsumer _resourceConsumer;
        [SerializeField] private EnemyScaner _enemyScaner;

        [SerializeField] private CharacterConfig _characterConfig;

        private bool _isAttacking = false;
        private CancellationTokenSource _cancellationToken;

        public event Action AttackStarted;

        public event Action AttackEnded;

        public ResourceConsumer ResourceConsumer => _resourceConsumer;

        private void Awake() =>
            _enemyScaner.Initialize(_characterConfig);

        private void OnEnable()
        {
            _cancellationToken = new CancellationTokenSource();

            AttackLoop(_cancellationToken.Token).Forget();
        }

        private void OnDisable()
        {
            _cancellationToken?.Cancel();
            _cancellationToken = null;
        }

        public void AttackEnd()
        {
            _isAttacking = false;
            AttackEnded?.Invoke();
        }

        public void AttackStart()
        {
            if (_isAttacking == false)
                AttackEnd();

            Collider enemyCollider = _enemyScaner.DetectEnemies();

            if (enemyCollider == null)
                return;

            if (enemyCollider.TryGetComponent(out BossHealth boss)
                && _resourceConsumer.TryConsumeResource())
            {
                _isAttacking = true;
                boss.TakeDamage(_characterConfig.Damage);
                AttackStarted?.Invoke();
            }
        }

        private async UniTask AttackLoop(CancellationToken cancellationToken)
        {
            while (cancellationToken.IsCancellationRequested == false)
            {
                AttackStart();
                await UniTask.Delay(TimeSpan.FromSeconds(_characterConfig.AttackTimer), cancellationToken: cancellationToken);
                AttackEnd();
            }
        }
    }
}