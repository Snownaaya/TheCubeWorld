using System;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Particles
{
    [RequireComponent(typeof(ParticleSystem))]
    public class PooledParticle : MonoBehaviour
    {
        [SerializeField] private ParticleTypes _particleType;
        [SerializeField] private ParticleSystem _particleSystem;

        private CompositeDisposable _compositeDisposable;

        public event Action<PooledParticle> OnFinished;

        public void Play() =>
            _particleSystem.Play();

        public void Stop() =>
            _particleSystem.Stop();
    }
}