using UnityEngine;

public class CharacterView : MonoBehaviour
{
    private const string IsIdling = nameof(IsIdling);
    private const string IsWalking = nameof(IsWalking);

    private Animator _animator;

    public void Initialize()
    {
        _animator = GetComponent<Animator>();
    }

    public void UpdateAnimation(bool isMoving)
    {        _animator.SetBool(IsIdling, !isMoving);
        _animator.SetBool(IsWalking, isMoving);
    }
}

//    public void StartIdle()
//    {
//        Debug.Log("StartIdle called, setting IsIdling = true");
//        _animator?.SetBool(IsIdling, true);
//    }

//    public void StopIdle()
//    {
//        Debug.Log("StopIdle called, setting IsIdling = false");
//        _animator?.SetBool(IsIdling, false);
//    }

//    public void StartWalk()
//    {
//        Debug.Log("StartWalk called, setting IsWalking = true");
//        _animator?.SetBool(IsWalking, true);
//    }

//    public void StopWalk()
//    {
//        Debug.Log("StopWalk called, setting IsWalking = false");
//        _animator?.SetBool(IsWalking, false);
//    }
//}