using Assets.Scripts.Enemies.Boss;
using Assets.Scripts.Particles;
using Assets.Scripts.Particles.ParticliesSpawners;
using UnityEngine;

public class CharacterView : MonoBehaviour
{
    private const string IsIdling = nameof(IsIdling);
    private const string IsWalking = nameof(IsWalking);
    private const string IsMovement = nameof(IsMovement);
    private const string IsAttack = nameof(IsAttack);
    private const string AttackState = nameof(AttackState);

    [SerializeField] private CharacterAttackEffects _effects;
    [SerializeField] private PooledParticle _pooledParticle;
    [SerializeField] private BossTarget _bossTarget;

    private Animator _animator;

    public void Initialize()
    {
        _animator = GetComponent<Animator>();
        _effects.Initialize(_pooledParticle, _bossTarget.transform);
    }

    public void StartIdle() =>
        _animator?.SetBool(IsIdling, true);

    public void StopIdle() =>
        _animator?.SetBool(IsIdling, false);

    public void StartWalk() =>
        _animator?.SetBool(IsWalking, true);

    public void StartMovement() =>
        _animator?.SetBool(IsMovement, true);

    public void StartAttackState() =>
        _animator?.SetBool(AttackState, true);

    public void StopMovement() =>
        _animator?.SetBool(IsMovement, false);

    public void StopWalk() =>
        _animator?.SetBool(IsWalking, false);

    public void StartAttack()
    {
        _effects.SpawnParticle();
        _animator?.SetBool(IsAttack, true);
    }

    public void StopAttack()
    {
        _effects.ReturnParticle(_pooledParticle);
        _animator?.SetBool(IsAttack, false);
    }
}
