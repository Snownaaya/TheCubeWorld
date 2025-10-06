using Assets.Scripts.HealthCharacters.Characters;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Particles;
using Assets.Scripts.Loss;
using Reflex.Attributes;
using UnityEngine;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(CharacterHealth))]
    public class Character : MonoBehaviour
    {
        [SerializeField] private CharacterView _characterView;
        [SerializeField] private Transform _characterModel;

        private CharacterHealth _characterHealth;
        private IParticleSpawner _characterEffects;

        public Transform CharacterModel => _characterModel;
        public CharacterHealth Health => _characterHealth;

        [Inject]
        public void Construct(IParticleSpawner particleSpawner)
        {
            _characterEffects = particleSpawner;
            _characterEffects.Initialize(_characterModel);
        }

        private void Awake()
        {
            _characterHealth = GetComponent<CharacterHealth>();
            _characterModel = transform;
            _characterView.Initialize();
        }

        private void OnEnable() =>
            _characterHealth.Died += ProccesCollision;

        private void OnDisable() =>
            _characterHealth.Died -= ProccesCollision;

        public void ProccesCollision(ILoss loss)
        {
            if (loss is LossCollision || loss is LossHealth)
            {
                _characterEffects.SpawnParticle(ParticleTypes.CharacterDeath, transform);
                _characterView.StopWalk();
                _characterView.StopIdle();
                _characterView.StopAttack();
                _characterModel.gameObject.SetActive(false);
            }
        }
    }
}