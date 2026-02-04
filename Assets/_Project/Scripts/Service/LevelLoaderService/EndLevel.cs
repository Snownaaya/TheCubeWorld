using Assets.Scripts.UI.HealthCharacters.Characters;
using System;
using UnityEngine;

namespace Assets.Scripts.Service.LevelLoaderService
{
    [RequireComponent(typeof(BossHealth))]
    public class EndLevel : MonoBehaviour
    {
        private BossHealth _health;

        public event Action LevelEnded;

        private void Awake() =>
            _health = GetComponent<BossHealth>();

        private void OnEnable() =>
            _health.Died += OnDied;

        private void OnDisable() =>
            _health.Died -= OnDied;

        private void OnDied() =>
            LevelEnded?.Invoke();
    }
}