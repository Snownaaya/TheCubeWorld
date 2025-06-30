using Assets.Scripts.HealthCharacters;
using Assets.Scripts.HealthCharacters.Characters;
using Assets.Scripts.Interfaces;
using UnityEngine;
using System;

namespace Assets.Scripts.LevelLoader
{
    [RequireComponent(typeof(BossHealth))]
    public class EndLevel : MonoBehaviour
    {
        private IHealth _health;

        public event Action LevelEnded;

        private void Awake() =>
            _health = GetComponent<Health>();

        private void OnEnable() =>
               _health.Died += OnDied;

        private void OnDisable() =>
               _health.Died -= OnDied;

        public bool IsDeath()
        {
            if (IsDeath())
            {
                _health.CheckHealth();
                LevelEnded?.Invoke();
                return true;
            }

            return false;
        }

        private void OnDied(ILoss loss) =>
            LevelEnded?.Invoke();
    }
}
