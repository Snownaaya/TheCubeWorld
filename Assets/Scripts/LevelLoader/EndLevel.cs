using Assets.Scripts.Interfaces;
using System;
using UnityEngine;

namespace Assets.Scripts.LevelLoader
{
    [RequireComponent(typeof(Assets.Scripts.Health.Health))]
    public class EndLevel : MonoBehaviour
    {
        private IHealth _health;

        public event Action LevelEnded;

        private void Awake() =>
            _health = GetComponent<Assets.Scripts.Health.Health>();

        public bool IsDeath() =>
            _health.CheckHealth();
    }
}
