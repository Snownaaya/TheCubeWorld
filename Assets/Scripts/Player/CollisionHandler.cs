using UnityEngine;
using Assets.Scripts.Interfaces;
using Reflex.Attributes;
using Assets.Scripts.Other;
using System;
using Assets.Scripts.GameStateMachine.States;

[RequireComponent(typeof(Rigidbody))]
public class CollisionHandler : MonoBehaviour
{
    public event Action<ILoss> Died;

    private ISwitcher _stateSwitcher;

    [Inject]
    private void Construct(ISwitcher stateSwitcher) =>
        _stateSwitcher = stateSwitcher;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out LossCollision loss))
        {
            _stateSwitcher.SwitchState<LossState>();
            Died?.Invoke(loss);
        }
    }
}