using System;
using UnityEngine;

namespace Assets.Scripts.Datas
{
    [CreateAssetMenu(fileName = "Character", menuName = "Character/ScriptableObject")]
    public class CharacterConfig : ScriptableObject
    {
        [Header("Movement")]
        [SerializeField] private float _speed = 3f;
        [SerializeField] private float _speedRate = 1.5f;

        [Header("Combat")]
        [SerializeField] private float _damage = 10f;
        [SerializeField] private float _detectionRadius = 10f;
        [SerializeField] private float _attackTimer = 1f;

        [Header("Health")]
        [SerializeField, Range(0, 100)] private float _health;

        public float Speed => _speed;
        public float SpeedRate => _speedRate;
        public float Damage => _damage;
        public float DetectionRadius => _detectionRadius;
        public float Health
        {
            get => _health;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Health cannot be negative.");
                _health = value;
            }
        }
        public float AttackTimer => _attackTimer;
    }
}