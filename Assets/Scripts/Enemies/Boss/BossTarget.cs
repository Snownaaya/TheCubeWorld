using Assets.Scripts.LevelLoader;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemies.Boss
{
    [RequireComponent(typeof(EndLevel), typeof(BossView))]
    public class BossTarget : MonoBehaviour
    {
        [SerializeField] private float _bossAnimationDuration;

        private BossView _bossView;
        private EndLevel _endlevel;

        private void Awake()
        {
            _endlevel = GetComponent<EndLevel>();
            _bossView = GetComponent<BossView>();
        }

        private void OnEnable() =>
            _endlevel.LevelEnded += OnLevelEnded;

        private void OnDisable() =>
            _endlevel.LevelEnded -= OnLevelEnded;

        private void OnLevelEnded() =>
            StartCoroutine(DieCoroutine());

        private IEnumerator DieCoroutine()
        {
            var wait = new WaitForSeconds(_bossAnimationDuration);

            _bossView.StopAttack();
            _bossView.StopIdle();
            _bossView.StartDeath();

            yield return wait;
            gameObject.SetActive(false);
        }
    }
}