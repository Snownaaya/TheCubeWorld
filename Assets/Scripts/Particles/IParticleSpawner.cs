using UnityEngine;

namespace Assets.Scripts.Particles
{
    public interface IParticleSpawner
    {
        void Initialize(Transform transform);
        PooledParticle SpawnParticle(ParticleTypes particleType, Transform transform);
        void ReturnParticle(PooledParticle pooledParticle);
    }
}
