namespace Assets.Scripts.UI.HealthCharacters.Characters
{
    using System;
    using Assets.Scripts.Interfaces;
    using Assets.Scripts.Loss;
    using UnityEngine;

    public class CharacterHealth : Health
    {
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

                //var message = () => Debug.Log("");
        }
    }
}