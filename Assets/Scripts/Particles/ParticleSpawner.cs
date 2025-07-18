﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Particles
{
    public class ParticleSpawner : PoolObject<PooledParticle>
    {
        [SerializeField] private List<ParticlePrefabEntry> _particleEntries = new();

        private Transform _transform;

        private Dictionary<ParticleTypes, PooledParticle> _partilclies = new();

        public void Initialize(Transform transform) =>
            _transform = transform;

        public void ReturnParticle(PooledParticle pooledParticle)
        {
            Push(pooledParticle);
            pooledParticle.Stop();
        }

        public PooledParticle SpawnParticle(ParticleTypes particleType, Transform transform)
        {
            foreach (ParticlePrefabEntry entry in _particleEntries)
            {
                if (!_partilclies.ContainsKey(entry.Type))
                    _partilclies.Add(entry.Type, entry.Prefab);
            }

            if (!_partilclies.TryGetValue(particleType, out PooledParticle prefab))
                return null;

            PooledParticle pooledParticle = Pull(prefab);
            pooledParticle.transform.position = transform.position;
            pooledParticle.Play();
            return pooledParticle;
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