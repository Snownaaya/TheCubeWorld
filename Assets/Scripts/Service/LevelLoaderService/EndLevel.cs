using Assets.Scripts.HealthCharacters.Characters;
using UnityEngine;
using System;
using Assets.Scripts.Interfaces;
using Assets.Scripts.GameStateMachine.States;
using Reflex.Attributes;

namespace Assets.Scripts.Service.LevelLoaderService
{
    [RequireComponent(typeof(BossHealth))]
    public class EndLevel : MonoBehaviour
    {
        private BossHealth _health;
        private ISwitcher _switcher;

        public event Action LevelEnded;

        private void Awake() =>
            _health = GetComponent<BossHealth>();

        [Inject]
        private void Construct(ISwitcher switcher) =>
            _switcher = switcher;

        private void OnEnable() =>
            _health.Died += OnDied;

        private void OnDisable() =>
            _health.Died -= OnDied;

        private void OnDied()
        {
            _switcher.SwitchState<EndLevelState>();
            LevelEnded?.Invoke();
        }
    }
}