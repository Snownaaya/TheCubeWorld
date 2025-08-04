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

        private void Start() =>
            _bossTargetService.SetTarget(this);

        public void Construct(IBossTargetService bossTargetService) =>
            _bossTargetService = bossTargetService;

        public Vector3 GetTargetPosition() =>
            _transform.position;

        public Transform GetTargetTransform() =>
            _transform;

        public bool IsValidTarget() =>
            _isActive && gameObject.activeInHierarchy;
    }
}