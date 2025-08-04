using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Enemies.Boss
{
    [RequireComponent(typeof(BossView))]
    public class BossCollisionTrigger : MonoBehaviour
    {
        [SerializeField] private BossAttacker _attacker;

        private BossView _bossView;

        private void Awake()
        {
            _bossView = GetComponent<BossView>();
            _bossView.Init();
        }

        private void Start() =>
            StartCoroutine(_attacker.AttackRoutine());

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Character character))
            {
                _bossView.StopIdle();
                _bossView.StartAttack();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Character character))
            {
                _bossView.StartIdle();
                _bossView.StopAttack();
            }
        }
    }
}