using Assets.Scripts.Particles;
using UnityEngine;

namespace Assets.Scripts.Datas
{
    [CreateAssetMenu(fileName = "ParticleEffect", menuName = "ParticleEffect/ScriptableObject")]
    internal class ParticleEffectConfig : ScriptableObject
    {
        [SerializeField] private PooledParticle _pooledParticle;
        [SerializeField] private ParticleSpawner _particleSpawner;

        public PooledParticle PooledParticle => _pooledParticle;
        public ParticleSpawner ParticleSpawner => _particleSpawner;
    }
}
