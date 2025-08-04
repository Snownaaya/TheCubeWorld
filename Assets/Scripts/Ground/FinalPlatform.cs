using Assets.Scripts.Player;
using System;
using UnityEngine;

namespace Assets.Scripts.Ground
{
    public class FinalPlatform : MonoBehaviour
    {
        public event Action PlayerReachedFinalPlatform;

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.TryGetComponent(out Character character))
                PlayerReachedFinalPlatform?.Invoke();
        }
    }
}