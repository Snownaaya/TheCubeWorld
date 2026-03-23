namespace Assets.Scripts.Particles
{
    using UnityEngine;

    public interface IParticleSpawner
    {
        void Initialize(Transform transform);

        PooledParticle SpawnParticle(ParticleTypes particleType, Vector3 transform);
    }
}