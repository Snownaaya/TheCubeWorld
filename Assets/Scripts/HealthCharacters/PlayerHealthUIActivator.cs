using Assets.Scripts.Player.Attack;
using UnityEngine;

namespace Assets.Scripts.HealthCharacters
{
    public class PlayerHealthUIActivator : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private CharacterAttacker _characterAttacker;

        private void OnEnable()
        {
            _characterAttacker.AttackStarted += OnActivedHealth;
            _characterAttacker.AttackEnded += OnTurnOffHealth;
        }

        public void OnDisable()
        {
            _characterAttacker.AttackStarted -= OnActivedHealth;
            _characterAttacker.AttackEnded -= OnTurnOffHealth;
        }

        private void OnActivedHealth() =>
            _rectTransform.gameObject.SetActive(true);

        public void OnTurnOffHealth() =>
            _rectTransform.gameObject.SetActive(false);
    }
}