using Assets.Scripts.HealthCharacters.Characters;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Particles;
using Assets.Scripts.Loss;
using Reflex.Attributes;
using UnityEngine;
using System;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(CollisionHandler))]
    public class Character : MonoBehaviour
    {
        [SerializeField] private CharacterView _characterView;
        [SerializeField] private Transform _characterModel;

        private CollisionHandler _collisionHandler;
        private CharacterHealth _health;

        private IParticleSpawner _characterEffects;

        public Transform CharacterModel => _characterModel;
        public CharacterHealth CharacterHealth => _health;
        public event Action Died;

        [Inject]
        public void Construct(IParticleSpawner particleSpawner)
        {
            _characterEffects = particleSpawner;
            _characterEffects.Initialize(_characterModel);
        }

        private void Awake()
        {
            _health = GetComponent<CharacterHealth>();
            _collisionHandler = GetComponent<CollisionHandler>();
            _characterModel = transform;
            _characterView.Initialize();
        }

        private void OnEnable()
        {
            _collisionHandler.Died += ProccesCollision;
            _health.Died += ProccesCollision;
        }

        private void OnDisable()
        {
            _collisionHandler.Died -= ProccesCollision;
            _health.Died -= ProccesCollision;
        }

        public void ProccesCollision(ILoss loss)
        {
            if (loss is LossCollision || loss is LossHealth)
            {
                _characterEffects.SpawnParticle(ParticleTypes.CharacterDeath, transform);
                _characterView.StopWalk();
                _characterView.StopIdle();
                _characterView.StopAttack();
                _characterModel.gameObject.SetActive(false);
                Died?.Invoke();
            }
        }
    }
}