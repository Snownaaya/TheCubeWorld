using System;
using TMPro.EditorUtilities;
using UnityEngine;

namespace Assets.Scripts.Enemy.Boss
{
    public class BossCollisionTrigger : MonoBehaviour
    {
        private BossView _bossView;

        private void Awake()
        {
            _bossView = GetComponent<BossView>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Character character))
            {
                _bossView.StartAttack();
                _bossView.StopIdle();
            }
        }
    }
}
