using Reflex.Attributes;
using UnityEngine;

namespace Assets.Scripts.Enemies.Boss
{
    public class BossTarget : MonoBehaviour, IBossTarget
    {
        [SerializeField] private bool _isActive = true;

        private IBossTargetService _bossTargetService;

        private Transform _transform;

        private void Awake() =>
            _transform = transform;

        [Inject]
        public void Construct(IBossTargetService bossTargetService)
        {
            _bossTargetService = bossTargetService;
            _bossTargetService.SetCurrentTarget(this);
            Debug.Log($"BossTarget constructed with service: {_bossTargetService != null}");
        }

        //private void OnDestroy()
        //{
        //    if (_bossTargetService != null)
        //        _bossTargetService.ClearCurrentBoss();
        //}

        public Transform GetTargetTransform() =>
            _transform;

        public bool IsValidTarget() =>
            _isActive && gameObject.activeInHierarchy;
    }
}