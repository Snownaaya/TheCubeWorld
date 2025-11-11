using Assets.Scripts.Interfaces;
using Assets.Scripts.Datas;
using Assets.Scripts.Loss;
using UnityEngine;
using System;

namespace Assets.Scripts.UI.HealthCharacters.Characters
{
    public class CharacterHealth : Health
    {
        [SerializeField] private CharacterConfig _characterConfig;

        public bool IsDead => _isDead;

        public event Action<ILoss> Died;

        public override void NotifyDeath()
        {
            _isDead = true;
            Died?.Invoke(new LossHealth());
        }

        public void ResetHealth() =>
            Reset();

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out LossCollision loss))
            {
                _isDead = true;
                Died?.Invoke(loss);
            }
        }
    }
}