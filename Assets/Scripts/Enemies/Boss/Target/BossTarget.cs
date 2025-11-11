using Assets.Scripts.UI.HealthCharacters.Characters;
using Reflex.Attributes;
using UnityEngine;

namespace Assets.Scripts.Enemies.Boss.Target
{
    [RequireComponent(typeof(BossHealth))]
    public class BossTarget : MonoBehaviour, IBossTarget
    {
        [SerializeField] private bool _isActive = true;

        private IBossTargetService _bossTargetService;

        private Transform _transform;
        private BossHealth _bossHealth;

        public BossHealth BossHealth => _bossHealth;

        private void Awake()
        {
            _transform = transform;
            _bossHealth = GetComponent<BossHealth>();
        }

        [Inject]
        public void Construct(IBossTargetService bossTargetService)
        {
            _bossTargetService = bossTargetService;
            _bossTargetService.SetCurrentTarget(this);
        }

        public Vector3 GetTarget() =>
            _transform.position;

        public bool IsValidTarget() =>
            _isActive && gameObject.activeInHierarchy;
    }
}