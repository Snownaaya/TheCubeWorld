using UnityEngine;

namespace Assets.Scripts.Player.Attack
{
    public class AttackMediator : MonoBehaviour
    {
        [SerializeField] private CharacterAttacker _characterAttacker;
        [SerializeField] private CharacterView _characterView;

        private void OnEnable()
        {
            _characterAttacker.AttackStarted += OnAttackStarted;
            _characterAttacker.AttackEnded += OnAttackEnded;
        }

        private void OnDisable()
        {
            _characterAttacker.AttackStarted -= OnAttackStarted;
            _characterAttacker.AttackEnded -= OnAttackEnded;
        }

        private void OnAttackEnded()
        {
            _characterView.StopAttack();
            _characterView.StartIdle();
            _characterView.StartWalk();
        }

        private void OnAttackStarted()
        {
            _characterView.StartAttack();
            _characterView.StopIdle();
            _characterView.StopWalk();
        }
    }
}