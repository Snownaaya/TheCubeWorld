using UnityEngine;

namespace Assets.Scripts.Particles
{
    public interface IParticleSpawner
    {
        void Initialize(Transform transform);
        PooledParticle SpawnParticle(ParticleTypes particleType, Vector3 transform);
        void ReturnParticle(PooledParticle pooledParticle);
    }
}