using Assets.Scripts.UI.HealthCharacters.Characters;
using Assets.Scripts.Datas;
using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;
using System;

namespace Assets.Scripts.Player.Attack
{
    public class CharacterAttacker : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private CharacterView _characterView;
        [SerializeField] private ResourceConsumer _resourceConsumer;
        [SerializeField] private EnemyScaner _enemyScaner;

        [SerializeField] private CharacterConfig _characterConfig;

        private bool _isAttacking = false;
        private CancellationTokenSource _cancellationToken;

        public event Action AttackStarted;
        public event Action AttackEnded;

        private void OnEnable()
        {
            _cancellationToken = new CancellationTokenSource();

            AttackLoop(_cancellationToken.Token).Forget();
        }

        private void OnDisable()
        {
            _cancellationToken?.Cancel();
            _cancellationToken?.Dispose();
            _cancellationToken = null;
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

        public void AttackEnd()
        {
            _isAttacking = false;
            AttackEnded?.Invoke();
        }

        public void AttackStart()
        {
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
    }
}