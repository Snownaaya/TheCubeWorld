using UnityEngine;
using Reflex.Attributes;
using Assets.Scripts.Loss;
using Assets.Scripts.Particles;
using Assets.Scripts.Interfaces;
using Assets.Scripts.GameStateMachine.States;
using Assets.Scripts.HealthCharacters.Characters;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(CollisionHandler))]
    public class Character : MonoBehaviour, ITransformable
    {
        [SerializeField] private CharacterView _characterView;
        [SerializeField] private Transform _characterModel;

        private CollisionHandler _collisionHandler;
        private CharacterHealth _health;

        private ISwitcher _stateSwitcher;
        private IParticleSpawner _characterEffects;

        public Transform CharacterModel => _characterModel;

        [Inject]
        private void Construct(ISwitcher stateSwitcher, IParticleSpawner particleSpawner)
        {
            _stateSwitcher = stateSwitcher;
            _characterEffects = particleSpawner;
            _characterEffects.Initialize(_characterModel);
        }

        private void Awake()
        {
            _health = GetComponent<CharacterHealth>(); 
            _collisionHandler = GetComponent<CollisionHandler>();
            _characterModel = transform;
            _characterView.Initialize();
            DontDestroyOnLoad(this);
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

        private void ProccesCollision(ILoss loss)
        {
            if (loss is LossCollision || loss is LossHealth)
            {
                _characterEffects.SpawnParticle(ParticleTypes.CharacterDeath, transform);
                _characterView.StopWalk();
                _characterView.StopIdle();
                _characterView.StopAttack();
                _characterModel.gameObject.SetActive(false);
                _stateSwitcher.SwitchState<LossState>();
            }
        }
    }
}