using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Particles
{
    public class ParticleSpawner : PoolObject<PooledParticle>, IParticleSpawner
    {
        [SerializeField] private List<ParticlePrefabEntry> _particleEntries = new();

        private Transform _transform;
        private float _delay = 2f;

        private readonly Dictionary<ParticleTypes, PooledParticle> _partilclies = new();

        public void Initialize(Transform position) =>
            _transform = position;

        public PooledParticle SpawnParticle(ParticleTypes particleType, Vector3 position)
        {
            foreach (ParticlePrefabEntry entry in _particleEntries)
            {
                if (_partilclies.ContainsKey(entry.Type) == false)
                    _partilclies.Add(entry.Type, entry.Prefab);
            }
             
            if (_partilclies.TryGetValue(particleType, out PooledParticle prefab) == false)
                return null;

            PooledParticle pooledParticle = Pull(prefab);
            pooledParticle.transform.position = position;
            pooledParticle.Play();

            ReturnPool(pooledParticle).Forget();
            return pooledParticle;
        }

        private async UniTask ReturnPool(PooledParticle particle)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_delay));

            if (particle == null || particle.gameObject == null)
                return;

            Push(particle);
            particle.Stop();
        }

        [Serializable]
        private struct ParticlePrefabEntry
        {
            [SerializeField] private ParticleTypes _particleType;
            [SerializeField] private PooledParticle _pooledParticle;

            public PooledParticle Prefab => _pooledParticle;
            public ParticleTypes Type => _particleType;
        }
    }
}