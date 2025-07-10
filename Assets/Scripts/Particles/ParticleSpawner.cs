using UnityEngine;

namespace Assets.Scripts.Particles
{
    public class ParticleSpawner : PoolObject<PooledParticle>
    {
        private PooledParticle _pooledParticle;
        private Transform _transform;

        public void Initialize(PooledParticle pooledParticle, Transform transform)
        {
            _pooledParticle = pooledParticle;
            _transform = transform;
        }

        public void ReturnParticle(PooledParticle pooledParticle)
        {
            Push(pooledParticle);
            pooledParticle.Stop();
        }

        public PooledParticle SpawnParticle()
        {
            PooledParticle pooledParticle = Pull(_pooledParticle);
            pooledParticle.transform.position = _transform.position;
            pooledParticle.Play();
            return pooledParticle;
        }
    }
}