using Assets.Scripts.Interfaces;
using Assets.Scripts.Player;
using UnityEngine;
using System;

namespace Assets.Scripts.Ground
{
    public class FinalPlatform : MonoBehaviour, ILevelProgressMediator
    {
        public event Action PlayerReachedFinalPlatform;

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.TryGetComponent(out Character character))
                PlayerReachedFinalPlatform?.Invoke();
        }
    }
}