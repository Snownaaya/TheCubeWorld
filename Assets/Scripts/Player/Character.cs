using Assets.Scripts.UI.HealthCharacters.Characters;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Particles;
using Assets.Scripts.Loss;
using Reflex.Attributes;
using UnityEngine;
using Assets.Scripts.Service.AchievementServices;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(CharacterHealth))]
    public class Character : MonoBehaviour
    {
        [SerializeField] private CharacterView _characterView;
        [SerializeField] private Transform _characterModel;

        private CharacterHealth _characterHealth;
        private IParticleSpawner _characterEffects;
        private DeathTrackerService _deathTracker;

        public Transform CharacterModel => _characterModel;
        public CharacterHealth Health => _characterHealth;

        [Inject]
        public void Construct(IParticleSpawner particleSpawner,
            DeathTrackerService deathTracker)
        {
            _characterEffects = particleSpawner;
            _characterEffects.Initialize(_characterModel);
            _deathTracker = deathTracker;
        }

        private void Awake()
        {
            _characterHealth = GetComponent<CharacterHealth>();
            _characterModel = transform;
            _characterView.Initialize();
        }

        private void OnEnable()
        {
            _characterHealth.Died += ProccesCollision;
            _deathTracker?.Register(Health);
        }

        private void OnDisable()
        {
            _characterHealth.Died -= ProccesCollision;
            _deathTracker?.Unregister(Health);
        }

        public void ProccesCollision(ILoss loss)
        {
            if (loss is LossCollision || loss is LossHealth)
            {
                _characterEffects.SpawnParticle(ParticleTypes.CharacterDeath, transform.position);
                _characterView.StopWalk();
                _characterView.StopIdle();
                _characterView.StopAttack();
                _characterModel.gameObject.SetActive(false);
            }
        }
    }
}