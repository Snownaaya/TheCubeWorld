namespace Assets.Scripts.Particles
{
    using UnityEngine;

    public class PooledParticle : MonoBehaviour
    {
        [SerializeField] private ParticleTypes _particleType;
        [SerializeField] private ParticleSystem _particleSystem;

        public void Play() =>
            _particleSystem.Play();

        public void Stop() =>
            _particleSystem.Stop();
    }
}