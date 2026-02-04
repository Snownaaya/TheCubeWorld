using Assets.Scripts.Interfaces;
using Assets.Scripts.Loss;
using UnityEngine;
using System;

namespace Assets.Scripts.UI.HealthCharacters.Characters
{
    public class CharacterHealth : Health
    {
        public bool IsDead => _isDead;

        public event Action<ILoss> Died;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out LossCollision loss))
            {
                _isDead = true;
                Died?.Invoke(loss);
            }
        }

        protected override void NotifyDeath()
        {
            _isDead = true;
            Died?.Invoke(new LossHealth());
        }
    }
}