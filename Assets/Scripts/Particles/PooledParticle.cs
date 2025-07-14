using UnityEngine;

namespace Assets.Scripts.Particles
{
    [RequireComponent(typeof(ParticleSystem))]
    public class PooledParticle : MonoBehaviour
    {
        [SerializeField] private ParticleTypes _particleType;
        [SerializeField] private ParticleSystem _particleSystem;

        public void Awake() =>
            _particleSystem = GetComponent<ParticleSystem>();

        public void Play() =>
            _particleSystem.Play();

        public void Stop() =>
            _particleSystem.Stop();
    }
}