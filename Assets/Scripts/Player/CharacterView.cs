using UnityEngine;

public class CharacterView : MonoBehaviour
{
    private const string IsIdling = nameof(IsIdling);
    private const string IsWalking = nameof(IsWalking);
    private const string IsMovement = nameof(IsMovement);
    private const string IsAttack = nameof(IsAttack);
    private const string AttackState = nameof(AttackState);

    private Animator _animator;

    public void Initialize() =>
        _animator = GetComponent<Animator>();

    public void StartIdle() =>
        _animator?.SetBool(IsIdling, true);

    public void StopIdle() =>
        _animator?.SetBool(IsIdling, false);

    public void StartWalk() =>
        _animator?.SetBool(IsWalking, true);

    public void StopWalk() =>
        _animator?.SetBool(IsWalking, false);
}
