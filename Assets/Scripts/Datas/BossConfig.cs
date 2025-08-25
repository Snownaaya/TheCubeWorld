using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Datas
{
    [CreateAssetMenu(fileName = "Boss", menuName = "Boss/ScriptableObject")]
    public class BossConfig : ScriptableObject
    {
        [Header("Health")]
        [SerializeField] private float _health = 100f;

        [Header("Attack")]
        [SerializeField] private float _attackRadius = 10f;
        [SerializeField] private float _delay = 1f;
        [SerializeField] private float _damage = 10f;

        [Header("Animation")]
        [SerializeField] private float _animatiobnDuration = 2f;

        public float Health => _health;
        public float AttackRadius => _attackRadius;
        public float Delay => _delay;
        public float Damage => _damage;
        public float AnimationDuration => _animatiobnDuration;
    }
}
