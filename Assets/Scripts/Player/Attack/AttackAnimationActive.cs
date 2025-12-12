using UnityEngine;

namespace Assets.Scripts.Player.Attack
{
    public class AttackAnimationActive : MonoBehaviour
    {
        [SerializeField] private CharacterAttacker _characterAttacker;
        [SerializeField] private CharacterView _currentCharacterView;

        public void Initialize(CharacterView characterView) =>
            _currentCharacterView = characterView;

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
            _currentCharacterView.StopAttack();
            _currentCharacterView.StartIdle();
            _currentCharacterView.StartWalk();
        }

        private void OnAttackStarted()
        {
            _currentCharacterView.StartAttack();
            _currentCharacterView.StopIdle();
            _currentCharacterView.StopWalk();
        }
    }
}