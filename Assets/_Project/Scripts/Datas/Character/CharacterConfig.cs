using UnityEngine;

namespace Assets.Scripts.Datas.Character
{
    [CreateAssetMenu(fileName = "Character", menuName = "Character/ScriptableObject")]
    public class CharacterConfig : ScriptableObject
    {
        [Header("Movement")]
        [SerializeField] private float _speed;
        [SerializeField] private float _speedRate;

        [Header("Combat")]
        [SerializeField] private float _damage;
        [SerializeField] private float _detectionRaduis;
        [SerializeField] private float _attackTimer;

        public float Speed => _speed;
        public float SpeedRate => _speedRate;
        public float Damage => _damage;
        public float DetectionRadius => _detectionRaduis;
        public float AttackTimer => _attackTimer;
    }
}