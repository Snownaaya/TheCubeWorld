using UnityEngine;

namespace Assets.Scripts.Datas
{
    [CreateAssetMenu(fileName = "Boss", menuName = "Boss/ScriptableObject")]
    public class BossConfig : ScriptableObject
    {
        [Header("Health")]
        [SerializeField] private float _health;

        [Header("Attack")]
        [SerializeField] private float _delay;
        [SerializeField] private float _attackRadius;
        [SerializeField] private float _damage;

        [Header("Animation")]
        [SerializeField] private float _animatiobnDuration ;

        public float Health => _health;
        public float AttackRadius => _attackRadius;
        public float Delay => _delay;
        public float Damage => _damage;
        public float AnimationDuration => _animatiobnDuration;
    }
}
